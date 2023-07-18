using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace A_mvvm_1.ViewModels
{
    //为了实现属性更新继承通知接口
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            // 把命令通过属性绑定到按钮
            // 把lambda表达式作为委托类型传递给RelayCommand
            SearchCommand = new RelayCommand((arg) =>
            {
                MessageBox.Show("您点击了按钮");
                // 此时会激活属性更新
                Title = "AAA";   
            });
        }

        private string _title = "默认值";

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value; 
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public ICommand SearchCommand 
        { 
            get; 
            set; 
        }

    }
}
