using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_INotifyPropertyChanged
{
    // 外部命令可单独抽离到单独文件中，实现ICommand接口，用于触发该命令
    public class MyCommand : ICommand
    {
        // 通过构造函数把外部函数传入ICommand
        public MyCommand(Action action)
        {
            executeAction = action;
        }

        Action executeAction;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeAction();
        }
    }
}
