using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models
{
    public class Marks
    {
        
        [Key]
        public int Id { get; set; }
        public Course course { get; set; }
        public Student student { get; set; }
        public int FirstEx { get; set; }
        public int SecondEx { get; set; }
        public int Participation { get; set; }
        public int FinalEx { get; set; }
        public int TotalMark { get; set; }
        public int Status { get; set; }
    }
}
