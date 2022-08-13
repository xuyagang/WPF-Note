using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Binding
{
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