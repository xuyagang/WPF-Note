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

namespace A_TreeView
{
    /// <summary>
    /// HierachicalDataTemplateTest.xaml 的交互逻辑
    /// https://blog.csdn.net/qq_43026206/article/details/87797081
    /// https://blog.csdn.net/crf_moonlight/article/details/80935268
    /// 
    /// </summary>
    public partial class HierachicalDataTemplateTest : UserControl
    {
        public HierachicalDataTemplateTest()
        {
            InitializeComponent();


            DefinitionNode dNode = new DefinitionNode()
            {
                Name = "一级",
                Children = new List<DefinitionNode>()
                {
                    new DefinitionNode()
                    {
                        Name = "二级",
                        Children = new List<DefinitionNode>()
                        {
                            new DefinitionNode() {Name = "三级" },
                            new DefinitionNode() {Name = "三级" }
                        }
                    }
                }
            };

            DefinitionNode dNode2 = new DefinitionNode()
            {
                Name = "一级",
                Children = new List<DefinitionNode>()
                {
                    new DefinitionNode { Name = "二级" },
                    new DefinitionNode {Name = "二级" }
                }
            };
            List<DefinitionNode> list = new List<DefinitionNode> { dNode, dNode2 };
            treeView.ItemsSource = list;
        }
    }


    public class DefinitionNode
    {
        public string Name { get; set; }
        public IList<DefinitionNode> Children { get; set; }
    }



}
