using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace WPF_INotifyPropertyChanged_Simple
{
    // 外部程序类
    public class MainViewModel : INotifyPropertyChanged
    {
        // 创建一个外部命令类型的属性
        public MyCommand ShowCommand { get; set; }

        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }


        #region 方法0 - 针对单个属性的方式
        private string name;
        public string Name
        {
            get { return name; }
            // 调用事件
            set
            {
                name = value;
                // 传入要通知更改的属性名字符串
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        // 这是另一个属性，如果还有多个属性通知，可以把通用的部分放入一个方法来通知界面更新
        private string title;
        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }
        #endregion


        public void Show()
        {
            Name = "点击了按钮";
            MessageBox.Show(Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
