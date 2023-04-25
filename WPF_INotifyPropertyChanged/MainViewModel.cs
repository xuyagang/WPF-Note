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
    /// <summary>
    /// 两种通知方法在执行时要分别注释掉另一个方法
    /// </summary>
    public class MainViewModel : ViewModeBase
    {
        // 创建一个外部命令类型的属性
        public MyCommand ShowCommand { get; set; }
        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }


        #region 第一种简化 - 需要传属性名称为参数
        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    // 调用事件
        //    set
        //    {
        //        name = value;
        //        // 通知方法继承自ViewModeBase基类
        //        OnPropertyChanged("Name");
        //    }
        //}

        //private string title;
        //public string Title
        //{
        //    get { return title; }
        //    set
        //    {
        //        title = value;
        //        OnPropertyChanged("Title");
        //        //PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Title"));
        //    }
        //}
        #endregion



        #region 第二种简化 - 不要传属性
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

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
                //OnPropertyChanged("Title");
                //PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }
        #endregion

        public void Show()
        {
            Name = "点击了按钮";
            Title = "标题";
            MessageBox.Show(Name);
        }
    }
}
