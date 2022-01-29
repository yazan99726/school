using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models
{
    public class Teacher
    {
        [Key]
        public int teacherId { get; set; }
        public string fname { get; set; }
        public string sname { get; set; }
        public string tname { get; set; }
        public string lname { get; set; }
        public string phone { get; set; }
        public Int64 ssn { get; set; }
    }
}
