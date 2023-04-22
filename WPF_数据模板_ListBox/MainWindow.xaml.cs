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

namespace WPF_数据模板_ListBox_base
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 以下写法需要淘汰
            for (int i = 0; i < 10; i++)
            {
                listTest1.Items.Add(new ListBoxItem()
                {
                    Content = new TextBlock()
                    {
                        Text = i.ToString()
                    }
                });
            }
        }
    }
}
