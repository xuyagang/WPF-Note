using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Binding
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            ShowCommand = new MyCommand(Show);
        }
        // UI与业务之间建立关系
        public MyCommand ShowCommand { get; set; }

        // 此处的代码和所有的UI没有关系
        public void Show()
        {
            MessageBox.Show("点击了按钮");
        }
    }
}
