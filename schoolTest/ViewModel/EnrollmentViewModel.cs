using schoolTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.ViewModel
{
    public class EnrollmentViewModel
    {
        public int enrollmentId { get; set; }
        public int courseId { get; set; }
        public List<Course> Courses { get; set; }
        public int studentId { get; set; }
        public List<Student> Students { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int semester { get; set; }
        public int year { get; set; }
    }
}
