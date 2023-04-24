using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_Command
{
    /// <summary>
    /// 通过命令给UI和行为建立联系
    /// </summary>
    public class MyCommand : ICommand
    {
        Action executeAction;
        /// <summary>
        /// 为了让命令调用具体的行为，需要在构造函数中传入委托
        /// </summary>
        /// <param name="action"></param>
        public MyCommand(Action action)
        {
            executeAction = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 通过该函数执行委托
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            executeAction();
        }
    }
}
