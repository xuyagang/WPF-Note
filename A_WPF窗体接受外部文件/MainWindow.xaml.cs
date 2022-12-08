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

namespace A_WPF窗体接受外部文件
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }



        #region 文件监听代码
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Drop += MainWindow_Drop;//接收拖拽的文件
            this.DragEnter += MainWindow_DragEnter;//用来设置拖拽的文件效果
            this.AllowDrop = true;//允许窗体Drop事件 注意默认是false(也就是不能进行拖文件进入操作）
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Link;
            else e.Effects = DragDropEffects.None;
        }

        private void MainWindow_Drop(object sender, DragEventArgs e)
        {
            //拖拽的文件路径
            string fileName = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            MessageBox.Show($"接收到文件 {fileName}");
        }
        #endregion



    }
}
