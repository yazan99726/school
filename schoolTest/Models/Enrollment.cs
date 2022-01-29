using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models
{
    public class Enrollment
    {
        [Key]
        public int enrollmentId { get; set; }
        public Course enrollCourse { get; set; }
        public Student enrollStudent { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public int semester { get; set; }
        public int year { get; set; }
    }
}
