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
    /// ComboBoxUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ComboBoxUserControl : UserControl
    {
        // 添加一个属性
        public List<Student> students { get; set; }


        public ComboBoxUserControl()
        {
            InitializeComponent();
            this.students = Student.GetStudents();   // 将返回值赋值给属性
            this.DataContext = this;
        }
    }
}
