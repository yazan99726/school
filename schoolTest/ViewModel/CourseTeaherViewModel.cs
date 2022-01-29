using schoolTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.ViewModel
{
    public class CourseTeaherViewModel
    {
        public int courseId { get; set; }
        public string courseName { get; set; }
        public int maxMark { get; set; }
        public int minMark { get; set; }
        public int teacherId { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
