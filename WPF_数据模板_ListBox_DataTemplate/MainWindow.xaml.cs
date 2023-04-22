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

namespace WPF_数据模板_ListBox_DataTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 创建颜色数据对象
            List<Color> listNum = new List<Color>();
            listNum.Add(new Color() { Code = "#FFB6C1", Name = "浅粉红" });
            listNum.Add(new Color() { Code = "#FFC0CB", Name = "粉红" });
            listNum.Add(new Color() { Code = "#DC143C", Name = "深红" });
            listNum.Add(new Color() { Code = "#FFF0F5", Name = "淡紫色" });

            listTest.ItemsSource = listNum;
        }
    }

    public class Color
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
