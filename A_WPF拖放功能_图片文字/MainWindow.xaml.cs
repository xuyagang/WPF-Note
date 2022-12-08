using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A_WPF拖放功能_图片文字
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 文本源数据
        /// </summary>
        private void source_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox objText = sender as TextBox;
            DragDrop.DoDragDrop(objText, objText, DragDropEffects.Copy);
        }

        /// <summary>
        /// 图片源数据
        /// </summary>
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image objImage = sender as Image;
            DragDrop.DoDragDrop(objImage, objImage.Source, DragDropEffects.Copy);
        }


        /// <summary>
        /// 目标位置
        /// </summary>
        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effects = DragDropEffects.Copy;
            else
                return;

            this.target.Content = e.Data.GetData(DataFormats.Text);
        }


        private void targetImg_Drop_1(object sender, DragEventArgs e)
        {
            e.Data.GetFormats();
            if (e.Data.GetDataPresent("System.Windows.Media.Imaging.BitmapFrameDecode"))
                e.Effects = DragDropEffects.Copy;
            else
            {
                return;
            }
            targetImg.Source = (ImageSource)e.Data.GetData("System.Windows.Media.Imaging.BitmapFrameDecode");
            //((Image)sender).Source = (ImageSource)e.Data.GetData("System.Windows.Media.Imaging.BitmapFrameDecode");
        }
    }
}
