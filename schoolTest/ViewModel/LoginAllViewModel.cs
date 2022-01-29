using schoolTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace schoolTest.ViewModel
{
    public class LoginAllViewModel
    {
        public int id { get; set; }
        public int UserNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string confirmPass { get; set; }
        
        public int StudentId { get; set; }
        public List<Student> students { get; set; }
        
        public int teacherId { get; set; }
        public List<Teacher> teachers { get; set; }
    }
}
