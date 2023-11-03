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
    /// CheckboxTreeView.xaml 的交互逻辑
    /// </summary>
    public partial class CheckboxTreeView : UserControl
    {
        List<TreeItem> treeItems;
        public CheckboxTreeView()
        {
            InitializeComponent();
            InitTree();
            folderTree.ItemsSource = treeItems;
        }
        /// <summary>
        /// 初始化树
        /// </summary>
        void InitTree()
        {
            treeItems = new List<TreeItem>();
            TreeItem t1 = new TreeItem("生产院1");

            TreeItem t1p1 = new TreeItem("项目1");
            t1p1.Parent = t1;
            t1.Children.Add(t1p1);

            TreeItem t1p1s1 = new TreeItem("阶段1");
            t1p1s1.Parent = t1p1;
            t1p1.Children.Add(t1p1s1);


            TreeItem t1p2 = new TreeItem("项目2");
            t1p2.Parent = t1;
            t1.Children.Add(t1p2);



            TreeItem t2 = new TreeItem("生产院2");
            TreeItem t3 = new TreeItem("生产院3");




            treeItems.Add(t1);
            treeItems.Add(t2);
            treeItems.Add(t3);
        }

        public TreeViewItem CreatTreeItem(TreeView treeView, List<string> treeBranch, string viewName = null)
        {
            TreeViewItem mtree = null;
            ItemCollection itemCollection = treeView.Items;
            for (int i = 0; i < treeBranch.Count; i++)
            {
                bool ifhave = false;
                for (int j = 0; j < itemCollection.Count; j++)
                {
                    mtree = itemCollection[j] as TreeViewItem;
                    if (mtree.Header.ToString() == treeBranch[i])
                    {
                        itemCollection = mtree.Items;
                        ifhave = true;
                        break;
                    }
                }
                if (ifhave == false)
                {
                    mtree = new TreeViewItem();
                    mtree.Header = treeBranch[i];
                    itemCollection.Add(mtree);
                    itemCollection = mtree.Items;
                }
            }

            if (viewName == null) { return mtree; }
            else
            {
                TreeViewItem newtree = new TreeViewItem();
                newtree.Header = viewName;
                itemCollection.Add(newtree);
                return newtree;
            }
        }


    }
}
