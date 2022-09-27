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
        // 为了让命令调用具体的行为，这里需要实现构造函数，传入一个委托
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
