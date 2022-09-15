using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 极客学院_Binding
{
    internal class Student : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { 
                name = value; 
                if( this.PropertyChanged != null )
                {
                    // 属性发生改变后，触发通知功能
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs( "Name" ) );
                }
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { 
                age = value;
                if (this.PropertyChanged != null)
                {
                    // 属性发生改变后，触发通知功能
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value;
                if (this.PropertyChanged != null)
                {
                    // 属性发生改变后，触发通知功能
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Sex"));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
