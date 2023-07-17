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
        // 声明委托对象
        private Action<object> _executeAction;
        public RelayCommand(Action<object> action)
        {
            _executeAction = action;
        }


        public event EventHandler CanExecuteChanged;

        public Func<bool> IsCanExecute { get; set; }

        public bool CanExecute(object parameter)
        {
            if (IsCanExecute == null)
            {
                return true;
            }
            return IsCanExecute.Invoke();
        }

        // 调用命令时会调用该函数
        public void Execute(object parameter)
        {
            _executeAction?.Invoke(parameter);
        }
    }
}