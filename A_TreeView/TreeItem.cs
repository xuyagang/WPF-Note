using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_TreeView
{
    class TreeItem : INotifyPropertyChanged
    {
        /// <summary>
        /// 节点文字
        /// 文件夹名称
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 节点路径
        /// 文件夹路径
        /// </summary>
        public string DirPath { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeItem Parent { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public ObservableCollection<TreeItem> Children { get; set; }
        //ObservableCollection 在需要跟踪集合变化并自动在 UI 中反映这些变化的场景中非常有用
        //它实现了 INotifyCollectionChanged 接口，该接口在集合中添加、移除或修改项时提供通知

        bool _isEnable = true;
        public bool IsEnable
        {
            get { return _isEnable; }
            set { _isEnable = value; }
        }

        /// <summary>
        /// 节点选择状态
        /// </summary>
        bool? _isChecked = false;
        /// <summary>
        /// 节点选择状态
        /// </summary>
        public bool? IsChecked
        {
            get => _isChecked;
            set => SetCheckState(value);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">节点名称</param>
        public TreeItem(string name, string path)
        {
            Text = name;
            DirPath = path;
            Children = new ObservableCollection<TreeItem>();
        }

        /// <summary>
        /// 设置节点状态并同步更新关联父子节点的状态
        /// </summary>
        /// <param name="value">当前节点勾选状态</param>
        /// <param name="updateChildren">是否更新子节点</param>
        /// <param name="updateParent">是否更新父节点</param>
        void SetCheckState(bool? value, bool updateChildren = true, bool updateParent = true)
        {
            //属性设置时先检查是否和当前值一致
            if (value == _isChecked) return;
            _isChecked = value;

            // 对于子节点,如果有值且需要,则递归更新
            if (updateChildren && _isChecked.HasValue)
                Children.ToList().ForEach(item => item.SetCheckState(_isChecked, true, false));

            // 对于父节点,如果父节点不为空且有需要,则递归更新
            if (updateParent && Parent != null)
                Parent.VerifyCheckState();

            OnPropertyChanged("IsChecked");
        }

        /// <summary>
        /// 更新父节点时,递归更新所有父节点
        /// </summary>
        void VerifyCheckState()
        {
            bool? parentState = null;
            //遍历子节点计算父节点状态
            for (int i = 0; i < Children.Count; i++)
            {
                bool? current = Children[i].IsChecked;
                if (i == 0) parentState = current;
                else if (parentState != current)
                {
                    parentState = null;
                    break;
                }
            }
            // 递归更新父节点
            SetCheckState(parentState, false);
        }

        /// <summary>
        /// 属性值变化事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        //当属性值发生变化时，PropertyChangedEventHandler 会被调用，以通知订阅者（通常是 UI 元素）该属性已被更新。
        //它接受两个参数：发送方对象（通常是拥有该属性的类的实例）和一个 PropertyChangedEventArgs 类的实例，其中包含有关已更改属性的信息

        /// <summary>
        /// 更新属性
        /// </summary>
        /// <param name="propName"></param>
        void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}