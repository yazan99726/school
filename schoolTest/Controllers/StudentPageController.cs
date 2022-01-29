using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolTest.Models;
using schoolTest.Models.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Controllers
{
    public class StudentPageController : Controller
    {
        private readonly ISchoolRepository<Student> studentRepository;

        public StudentPageController(ISchoolRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userNumber")==null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var session = HttpContext.Session.GetInt32("userNumber");
                var student = studentRepository.find(session.Value);
                return View(student);
            }
            
        }
        public IActionResult Info(int id)
        {
            return View();
        }
    }
}
