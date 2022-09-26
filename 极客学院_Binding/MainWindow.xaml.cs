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
    /// Interaction logic for MainWindow.xaml 交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student stu;

        public MainWindow()
        {
            InitializeComponent();
            // 数据源
            this.stu = new Student { Name = "Adam", Age = 10, Sex = "男" };

            // 方法二的语句
            this.DataContext = stu;


            //// 绑定对象
            //Binding stuNameBd = new Binding();
            //stuNameBd.Source = stu;
            //stuNameBd.Path = new PropertyPath("Name");   // 绑定路径
            //tbName.SetBinding(TextBox.TextProperty, stuNameBd);

            //Binding stuSexBd = new Binding();
            //stuSexBd.Source = stu;
            //stuSexBd.Path = new PropertyPath("Sex");   // 绑定路径
            //tbSex.SetBinding(TextBox.TextProperty, stuSexBd);

            //Binding stuAgeBd = new Binding();
            //stuAgeBd.Source = stu;
            //stuAgeBd.Path = new PropertyPath("Age");   // 绑定路径
            //tbAge.SetBinding(TextBox.TextProperty, stuAgeBd);

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number = new Random().Next(100);
            stu.Name = "Adam" + number.ToString();
            stu.Age = number;
            stu.Sex = number % 2 == 0 ? "男孩" : "女孩";
        }
    }
}
