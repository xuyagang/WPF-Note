using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Command
{
    /// <summary>
    /// 表现具体行为的类
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public MyCommand ShowCommand { get; set; }

        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }

        /// <summary>
        /// 方法和界面没有关系，任何界面都可调用
        /// </summary>
        public void Show()
        {
            Name = "点击了按钮!";
            Title = "我是标题";
            MessageBox.Show(Name);
        }




        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
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
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }





       




        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
