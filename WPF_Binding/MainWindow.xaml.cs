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

namespace WPF_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
            MainViewModel test = new MainViewModel();


            //创建绑定上下文
            this.DataContext = new Test()
            {
                Name = "张三"
            };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("点击了按钮！");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }


        //// 方法一：
        //private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    // 方法一：事件（可以在这里写赋值操作，但控件要指定名字）
        //    textbox1.Text = slider.Value.ToString();
        //    textbox2.Text = slider.Value.ToString();
        //    textbox3.Text = slider.Value.ToString();
        //}

        //// 方法一：
        //private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (double.TryParse(textbox1.Text, out double value))
        //    {
        //        slider.Value = value;
        //    }
        //}
    }
}
