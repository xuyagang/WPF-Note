using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace A_DispatcherFrameTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// http://t.csdnimg.cn/P1jMQ
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            rect.Width = 0d;

            //// 一个任务代表一个异步操作,在另一个线程干活,所以修改UI要借助Dispatcher来调度消息
            //Task taskrun = new Task(() =>
            //{
            //    double i = 0d;
            //    //不占用UI线程只是在修改矩形宽度时才会与UI线程交互
            //    for (i = 0d; i < 800d; i++)
            //    {
            //        //同步等待异步延迟
            //        Task.Delay(5).Wait();
            //        Action act = () => rect.Width++;
            //        //异步调用,立即返回
            //        //Dispatcher.BeginInvoke(act, DispatcherPriority.Render);
            //        Dispatcher.BeginInvoke(act, DispatcherPriority.Background);
            //    }
            //});
            //taskrun.Start();



            // 把所有的操作都放在UI线程
            // 因为for在UI线程上执行，UI更新的消息没有被及时处理,运行就卡住了
            //Action invkAct = () =>
            //{
            //    rect.Width++;
            //};
            //for (double i = 0d; i < 800d; i++)
            //{
            //    Task.Delay(5).Wait();
            //    Dispatcher.BeginInvoke(invkAct, DispatcherPriority.Render);
            //}



            // 要么把for循环写到Task上，以减轻UI线程的负担
            // 要么希望全在UI线程上执行，便真的要用上 DispatcherFrame 了
            // DispatcherFrame 类有个重要的属性——Continue
            // 允许你创建一个新的消息循环,如果它为真，那么这个循环会执行,否则不执行
            for (double n = 0d; n < 800d; n++)
            {
                Task.Delay(5).Wait();
                rect.Width++;
                ProcessMsgs();
            }
        }

        private void ProcessMsgs()
        {
            //创建一个新的 DispatcherFrame
            DispatcherFrame frame = new DispatcherFrame();
            Action<object> cb = obj =>
            {
                DispatcherFrame f = obj as DispatcherFrame;
                // 操作完成后，退出 DispatcherFrame
                f.Continue = false;
            };
            Dispatcher.BeginInvoke(cb, DispatcherPriority.Background, frame);

            //推入一个新的 DispatcherFrame，使得 UI 可以继续响应用户输入
            //要把一个 DispatcherFrame 插入到Dispatcher 中，就要调用 PushFrame 方法
            Dispatcher.PushFrame(frame);
        }
    }
}
