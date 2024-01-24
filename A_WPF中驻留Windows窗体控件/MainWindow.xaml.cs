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

namespace A_WPF中驻留Windows窗体控件
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 需要引用两个dll
        // system.windows.forms.dll
        // windowsformsintegration.dll
        public MainWindow()
        {
            InitializeComponent();

            // 默认显示windwos窗体控件的旧样式，为了支持新的风格，必须明确调用EnableVisualStyles()
            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void askedTextBox_MaskInputRejected(object sender, System.Windows.Forms.MaskInputRejectedEventArgs e)
        {
            tb.Text = "Error:" + e.RejectionHint.ToString();
        }
    }
}
