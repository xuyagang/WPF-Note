using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 极客学院_内容控件
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Update Data Success!");
        }


        int count = 0;
        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            count++;
            var repeatBtn = (RepeatButton)sender;
            repeatBtn.Content = string.Format("RepeatButton {0}.", count);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var toggleBtn = (ToggleButton)sender;
            var flag = toggleBtn.IsChecked;
            if (flag.HasValue)
            {
                if (flag.Value)
                {
                    MessageBox.Show("True");
                }
                else MessageBox.Show("False");
            }
            else MessageBox.Show("Indeteminate");
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Checked");
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("UnChecked");
        }

        private void ToggleButton_Indeterminate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Indeterminate");
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Expanded");
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Collapsed");
        }
    }
}
