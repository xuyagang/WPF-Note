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
    /// ListBoxUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ListBoxUserControl : UserControl
    {
        // 利用Student类创建一个集合
        public List<Student> Students { get; set; }
        public ListBoxUserControl()
        {
            InitializeComponent();
            Students = Student.GetStudents();
            this.DataContext = this;
        }

    }
}
