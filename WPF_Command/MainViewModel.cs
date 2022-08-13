using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Command
{
    // 后台程序
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
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





        public MyCommand ShowCommand { get; set; }


        public void Show()
        {
            Name = "点击了按钮!";
            Title = "我是标题";
            MessageBox.Show(Name);
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
