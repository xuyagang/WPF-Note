using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_TreeviewWithCheckBox
{
    class Node : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Node()
        {
            Children = new ObservableCollection<Node>();
        }


        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public Node Parent { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public ObservableCollection<Node> Children { get; set; }



        bool? _isChecked = false;
        public bool? IsChecked
        {
            get { return _isChecked; }
            // 此处的value是设置属性时传入的值
            set { this.SetIsChecked(value, true, true); }
        }

        /// <summary>
        /// 通知属性
        /// </summary>
        /// <param name="propertyName"></param>
        void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            // 等价于下面
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 设置Node选择状态
        /// </summary>
        /// <param name="value">要设置给Node的状态值</param>
        /// <param name="updateChilren"></param>
        /// <param name="updateParent"></param>
        void SetIsChecked(bool? value, bool updateChilren, bool updateParent)
        {
            // 如果传入值和当前值相同则直接返回
            if (value == _isChecked)
                return;

            // 否则设置Node状态为传入值
            _isChecked = value;

            // 检查并更新子元素
            if (updateChilren && _isChecked.HasValue)
            {
                foreach (Node node in Children)
                    node.SetIsChecked(_isChecked.Value, true, false);
            }

            // 检查并更新父元素
            if (updateParent && Parent != null)
                Parent.VerifyCheckState();

            this.OnPropertyChanged("IsChecked");
        }
        
        /// <summary>
        /// 检查Node选择状态
        /// </summary>
        void VerifyCheckState()
        {
            bool? state = null;
            for (int i = 0; i < Children.Count; ++i)
            {
                bool? current = Children[i].IsChecked;
                if (i == 0)
                    state = current;
                else if (state != current)
                {
                    state = null;
                    break;
                }
            }
            this.SetIsChecked(state, false, true);
        }
    }
}
