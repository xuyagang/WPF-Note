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

namespace 极客学院_CollectionControls
{
    /// <summary>
    /// StatusBarUserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class StatusBarUserControl1 : UserControl
    {
        public StatusBarUserControl1()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tb = (TextBox)sender;
            this.tblCount.Text = tb.Text.Length.ToString();
        }
    }
}
