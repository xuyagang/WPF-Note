using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Command
{
    /// <summary>
    /// 表现具体行为的类
    /// </summary>
    public class MainViewModel
    {
        public MyCommand ShowCommand { get; set; }
        /// <summary>
        /// 创建命令和行为的联系，将行为函数通过委托传递给命令
        /// </summary>
        public MainViewModel()
        {
            ShowCommand = new MyCommand(Show);
        }

        /// <summary>
        /// 方法和界面没有关系，任何界面都可调用
        /// </summary>
        public void Show()
        {
            MessageBox.Show("点击了按钮");
        }
    }
}
