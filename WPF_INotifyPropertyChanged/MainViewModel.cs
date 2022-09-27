using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace WPF_INotifyPropertyChanged
{
    // 外部程序类
    //public class MainViewModel : INotifyPropertyChanged
    public class MainViewModel : ViewModeBase   // 对应方法1
    {

        #region 通知更改模块 - 方法0
        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    // 调用事件
        //    set
        //    {
        //        name = value;
        //        // 传入要通知更改的属性名字符串
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
        //    }
        //}
        #endregion


        #region 方法1
        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    // 调用事件
        //    set
        //    {
        //        name = value;
        //        // 传入要通知更改的属性名字符串
        //        OnPropertyChanged("Name");
        //    }
        //}
        #endregion

        #region 方法2 - 不要传属性
        private string name;
        public string Name
        {
            get { return name; }
            // 调用事件
            set
            {
                name = value;
                // 传入要通知更改的属性名字符串
                OnPropertyChanged();
            }
        }
        #endregion




        // 创建一个外部命令类型的属性
        public MyCommand ShowCommand { get; set; }

        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }
        public void Show()
        {
            Name = "点击了按钮";
            MessageBox.Show(Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }




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


    // 把通知更改模块封装为一个类方法 - 版本1
    public class ViewModeBase : INotifyPropertyChanged
    {
        #region 第一次简化，需要传入属性名
        //public event PropertyChangedEventHandler PropertyChanged;
        //// 为了调用事件,实现自定义方法
        //public void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        #endregion

        #region 第二次简化，自动识别属性名
        public event PropertyChangedEventHandler PropertyChanged;
        // 为了调用事件,实现自定义方法
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }




}
