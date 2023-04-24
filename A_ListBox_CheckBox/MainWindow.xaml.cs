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

namespace A_ListBox_CheckBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Data> datas = new List<Data>();
            for (int i = 0; i < 10; i++)
            {
                datas.Add(new Data(i));
            }
            listbox.ItemsSource = datas;
        }
    }


    public class Data
    {
        public string Name;
        public Data(int name)
        {
            Name = name.ToString();
        }
    }
}
