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


        public static List<Student> GetStudents()
        {
            var studentList = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                studentList.Add(new Student
                {
                    Name = string.Format("张{0}",i+1),
                    Age = 10 + i,
                    Sex = i%2 == 0 ? "Boy" : "Girl",
                    Address = string.Format("四川省成都市{0}号", i+1)
                });
            }
            return studentList;
        }
    }
}
