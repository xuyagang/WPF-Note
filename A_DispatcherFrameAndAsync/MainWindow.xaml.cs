using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace A_DispatcherFrameAndAsync
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Thread longRunningThread = new Thread(LongRunningOperation);
        //    longRunningThread.Start();
        //}

        private void LongRunningOperation()
        {
            // 创建新的DispatcherFrame
            DispatcherFrame frame = new DispatcherFrame();

            // 在后台线程进行长时间运行
            ThreadPool.QueueUserWorkItem(_ => {
                Thread.Sleep(3000);
                // 操作完成后退出frame
                frame.Continue = false;
            });

            // 创建新的DispatcherFrame,使得UI可以相应用户输入
            // 会阻塞当前线程。它通过启动一个新的消息循环，使得当前线程能够继续处理其他消息
            Dispatcher.PushFrame(frame);

            Dispatcher.Invoke(() => MessageBox.Show("Long running operation completed"));
        }

        // 使用 async的替代方案，更简洁
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            MessageBox.Show("Completed");
        }
    }
}
