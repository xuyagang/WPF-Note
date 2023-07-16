using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace A_mvvm_1.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            // 把命令通过属性绑定到按钮
            SearchCommand = new RelayCommand((arg) =>
            {
                MessageBox.Show("您点击了按钮");
            });
        }

        private string _title = "默认值";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public ICommand SearchCommand { get; set; }

    }
}
