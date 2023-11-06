using System;
using System.Collections.Generic;
using System.IO;
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
            string rootPath = @"F:\DrawingChecker\TestData\生产院";
            DirectoryInfo rootInfo = new DirectoryInfo(rootPath);
            DirectoryInfo[] dirs = rootInfo.GetDirectories();
            dirs = dirs.OrderBy(x => x.Name, new PathHelper()).ToArray();


            for (int i = 0; i < dirs.Length; i++)
            {
                TreeItem item = new TreeItem(dirs[i].Name, dirs[i].FullName);
                treeItems.Add(item);
                GenerateTreeFromRoot(item);
            }
        }

        /// <summary>
        /// 通过树根对象递归创建树
        /// 先递归到包含专业文件夹层级，如果内部有文件夹则获取并显示，如果没有则返回
        /// </summary>
        /// <param name="treeItem"></param>
        void GenerateTreeFromRoot(TreeItem treeItem)
        {
            string rootPath = treeItem.DirPath;
            List<string> paths = Directory.GetDirectories(rootPath).ToList();

            List<string> innerFolderNames = new List<string>();
            paths.ForEach(path => innerFolderNames.Add(new DirectoryInfo(path).Name));
            bool flag = innerFolderNames.Contains("建筑") || innerFolderNames.Contains("结构") || innerFolderNames.Contains("电气") || 
                        innerFolderNames.Contains("暖通") || innerFolderNames.Contains("给排水");

            if (paths.Count == 0)
                return;
            else if (flag)
            {
                for (int i = 0; i < paths.Count; i++)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(paths[i]);
                    TreeItem item = new TreeItem(dirInfo.Name, paths[i]);
                    treeItem.Children.Add(item);
                    item.Parent = treeItem;
                }
                return;
            }
            else
            {
                for (int i = 0; i < paths.Count; i++)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(paths[i]);
                    TreeItem item = new TreeItem(dirInfo.Name, paths[i]);
                    treeItem.Children.Add(item);
                    item.Parent = treeItem;
                    GenerateTreeFromRoot(item);
                }
            }
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
