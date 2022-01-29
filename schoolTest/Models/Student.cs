using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models
{
    
    public class Student
    {
        [Key]
        public int student_Id { get; set; }
        public string FName { get; set; }
        public string SName { get; set; }
        public string TName { get; set; }
        public string LName { get; set; }
        public DateTime birthDate { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public int build_No { get; set; }
        public string GuardianPhone { get; set; }
    }
}
