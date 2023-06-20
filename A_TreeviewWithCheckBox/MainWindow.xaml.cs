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

namespace A_TreeviewWithCheckBox
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Node root;

        public MainWindow()
        {
            InitializeComponent();
            InitTree();
        }

        /// <summary>
        /// 初始化tree
        /// </summary>
        void InitTree()
        {
            root = new Node() { Name = "树根" };

            Node node1 = new Node() { Name = "甘肃" };
            Node node2 = new Node() { Name = "新疆" };
            Node node3 = new Node() { Name = "四川" };

            node1.Parent = root;
            node2.Parent = root;
            node3.Parent = root;

            root.Children.Add(node1);
            root.Children.Add(node2);
            root.Children.Add(node3);

            //--------------------------------------------

            Node node11 = new Node() { Name = "平凉" };
            Node node12 = new Node() { Name = "兰州" };
            Node node21 = new Node() { Name = "石河子" };
            Node node22 = new Node() { Name = "乌鲁木齐" };
            Node node31 = new Node() { Name = "成都" };
            Node node32 = new Node() { Name = "邛崃" };

            node11.Parent = node1;
            node12.Parent = node1;
            node21.Parent = node2;
            node22.Parent = node2;
            node31.Parent = node3;
            node32.Parent = node3;

            node1.Children.Add(node11);
            node1.Children.Add(node12);
            node2.Children.Add(node21);
            node2.Children.Add(node22);
            node3.Children.Add(node31);
            node3.Children.Add(node32);

            //--------------------------------------------

            Node node111 = new Node() { Name = "静宁" };
            Node node311 = new Node() { Name = "高新" };

            node111.Parent = node11;
            node311.Parent = node31;

            node11.Children.Add(node111);
            node31.Children.Add(node311);



            MyTree.ItemsSource = root.Children;
        }
    }
}
