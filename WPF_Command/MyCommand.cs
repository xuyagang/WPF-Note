using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Command
{
    public class MyCommand : ICommand
    {
        Action executeAction;
        // 把业务代码函数传入接口
        public MyCommand(Action action)
        {
            executeAction = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // 写入需要计算的函数
            executeAction();
        }
    }
}
