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

namespace A_ToolBarAndToolBarTray
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateAndShowNewWindow();
        }

        private void CreateAndShowNewWindow()
        {
            // 创建一个新的窗口
            Window newWindow = new Window
            {
                Title = "Dynamic Window",
                WindowStyle = WindowStyle.None,
                Width = 400,
                Height = 300,
                Left = 300,
                Top = 500,
                AllowsTransparency = true,
                ShowInTaskbar = false
            };

            // 创建一个 DockPanel 作为窗口的主容器
            DockPanel dockPanel = new DockPanel();
            newWindow.Content = dockPanel;

            // 创建一个 ToolBarTray
            ToolBarTray toolBarTray = new ToolBarTray();
            dockPanel.Children.Add(toolBarTray);
            DockPanel.SetDock(toolBarTray, Dock.Top);

            // 创建一个 ToolBar
            ToolBar toolBar = new ToolBar();
            toolBarTray.ToolBars.Add(toolBar);

            // 添加按钮到 ToolBar
            Button button1 = new Button { Content = "Button 1" };
            Button button2 = new Button { Content = "Button 2" };
            Button button3 = new Button { Content = "Button 3" };

            toolBar.Items.Add(button1);
            toolBar.Items.Add(button2);
            toolBar.Items.Add(button3);

            // 显示窗口
            newWindow.Show();
        }
    }
}
