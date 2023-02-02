using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 极客学院_CollectionControls
{
    /// <summary>
    /// 数据源
    /// </summary>
    public class Student
    {
        public string Name { get; set; }    
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }

        // 添加一个属性
        public List<Student> Children { get; private set; }
        // 构造函数中初始化属性
        public Student()
        {
            // 通过构造函数实例化属性是保证每次创建父对象的时候创建自己的子对象
            Children = new List<Student>();
        }

        public static List<Student> GetStudents()
        {
            var studentList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                var stu = new Student
                {
                    Name = string.Format("张{0}", i + 1),
                    Age = 10 + i,
                    Sex = i % 2 == 0 ? "Boy" : "Girl",
                    Address = string.Format("四川省成都市{0}号", i + 1)
                };
                // 每次创建父对象的时候，创建孩子对象，并添加孩子数据
                for (int j = 0; j < 5; j++)
                {
                    stu.Children.Add(new Student
                    {
                        Name = string.Format("张{0}孩子{1}", i + 1, j + 1),
                        Age = 10 + i,
                        Sex = i % 2 == 0 ? "Boy" : "Girl",
                        Address = string.Format("四川省成都市{0}号", i + 1)
                    });
                }
                studentList.Add(stu);
            }
            return studentList;
        }


        //public static List<Student> GetStudents()
        //{
        //    var studentList = new List<Student>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        studentList.Add(new Student
        //        {
        //            Name = string.Format("张{0}",i+1),
        //            Age = 10 + i,
        //            Sex = i%2 == 0 ? "Boy" : "Girl",
        //            Address = string.Format("四川省成都市{0}号", i+1)
        //        });
        //    }
        //    return studentList;
        //}
    }
}
