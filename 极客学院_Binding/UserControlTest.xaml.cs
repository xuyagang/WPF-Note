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

namespace 极客学院_Binding
{
    /// <summary>
    /// Interaction logic for UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    {
        public UserControlTest()
        {
            InitializeComponent();
            // 定义数据源
            List<Student> StudentList = new List<Student>();
            // 创建数据实例
            for (int i = 0; i < 10; i++)
            {
                var stu = new Student()
                {
                    Name = String.Format("张三{0}", i),
                };
                StudentList.Add(stu);
            }
            // 创建数据上下文
            this.DataContext = StudentList;
        }
    }
}
