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
    /// DataGirdUserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class DataGirdUserControl1 : UserControl
    {
        public List<Student> Students { get; set; }

        public DataGirdUserControl1()
        {
            InitializeComponent();
            Students = Student.GetStudents();
            this.DataContext = this;
        }
    }
}
