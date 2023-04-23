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

namespace WPF_Binding_Base
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tb1.Text = slider.Value.ToString();
            tb2.Text = slider.Value.ToString();
            tb3.Text = slider.Value.ToString();
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(double.TryParse(tb1.Text, out double value))
            {
                slider.Value = value;
            }
        }
    }
}
