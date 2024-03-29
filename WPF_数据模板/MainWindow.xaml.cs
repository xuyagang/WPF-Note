﻿using System;
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

namespace WPF_数据模板
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ////批量赋值测试，此时所有元素是一样的，因为属性值都一样
            //List<int> listNum = new List<int>();
            //for (int i = 0; i < 10; i++)
            //{
            //    listNum.Add(i);
            //}
            //listTest.ItemsSource = listNum;


            // 创建颜色数据对象，绑定数据后，每个项都有自己各自的颜色
            List<Color> listNum = new List<Color>();
            listNum.Add(new Color() { Code = "#FFB6C1", Name = "浅粉红" });
            listNum.Add(new Color() { Code = "#FFC0CB", Name = "粉红" });
            listNum.Add(new Color() { Code = "#DC143C", Name = "深红" });
            listNum.Add(new Color() { Code = "#FFF0F5", Name = "淡紫色" });

            grid.ItemsSource = listNum;
        }
    }

    public class Color
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
