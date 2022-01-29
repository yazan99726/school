using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models
{
    public class Course
    {
        [Key]
        public int courseId { get; set; }
        public string courseName { get; set; }
        public int maxMark { get; set; }
        public int minMark { get; set; }
        public Teacher teacher { get; set; }
        
    }
}
