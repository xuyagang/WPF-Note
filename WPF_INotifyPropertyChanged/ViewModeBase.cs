using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_INotifyPropertyChanged
{
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


        #region 第二次简化，自动获取调用属性的名称
        public event PropertyChangedEventHandler PropertyChanged;
        // 通过特性[CallerMemberName]获取调用属性名称
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
