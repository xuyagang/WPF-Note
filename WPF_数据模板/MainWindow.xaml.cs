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

namespace WPF_数据模板
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 通过自定义类赋值
            List<Color> listNum = new List<Color>();
            listNum.Add(new Color() { Code = "#FFB6C1", Name = "浅粉红" });
            listNum.Add(new Color() { Code = "#FFC0CB", Name = "粉红" });
            listNum.Add(new Color() { Code = "#DC143C", Name = "深红" });
            listNum.Add(new Color() { Code = "#FFF0F5", Name = "淡紫色" });

            // 测试2
            //listTest.ItemsSource = listNum;



            // 测试3
            grid.ItemsSource = listNum;




            ////批量赋值测试
            //List<int> listNum = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    listNum.Add(i);
            //}
            //listTest.ItemsSource = listNum;





            // 以下写法需要淘汰
            //for (int i = 0; i < 10; i++)
            //{
            //    list_test.Items.Add(new ListBoxItem()
            //    {
            //        Content = new TextBlock()
            //        {
            //            Text = i.ToString()
            //        }
            //    });
            //}
        }
    }

    public class Color
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
