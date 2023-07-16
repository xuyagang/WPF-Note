using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace A_mvvm_1.ViewModels
{
    // 我们不需要每个命令都去创建一个类 
    public class RelayCommand : ICommand
    {
        private Action<object> _executeAction;
        public RelayCommand(Action<object> action)
        {
            _executeAction = action;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _executeAction?.Invoke(parameter);
        }
    }
}
