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
    /// ListViewUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ListViewUserControl : UserControl
    {
        public List<Student> students { get; set; }
        public ListViewUserControl()
        {
            InitializeComponent();

            students = Student.GetStudents();
            this.DataContext = this;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var chbox = (CheckBox)sender;
            // 通过key找到资源
            var view = (GridView)this.FindResource("View1");
            this.listView.View = view;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var chbox = (CheckBox)sender;
            // 通过key找到资源
            var view = (GridView)this.FindResource("View0");
            this.listView.View = view;
        }
    }
}
