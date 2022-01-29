using schoolTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.ViewModel
{
    public class MarksCourseViewModel
    {
        public int id { get; set; }
        public int courseId { get; set; }
        public List<Course> Courses { get; set; }
        public int studentId { get; set; }
        public List<Student> Students { get; set; }
        public int FirstEx { get; set; }
        public int SecondEx { get; set; }
        public int Participation { get; set; }
        public int FinalEx { get; set; }
        public int TotalMark { get; set; }
        public int Status { get; set; }
    }
}
