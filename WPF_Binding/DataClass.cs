using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Binding
{
    /// <summary>
    /// 数据类
    /// </summary>
    class DataClass
    {
        private string name;
        public string Name {
            get {
                return name;
            }
            set { 
                name = value;
            }
        }
    }
}
