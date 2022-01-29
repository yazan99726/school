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
    public class TeacherPageController : Controller
    {
        private readonly ISchoolRepository<Teacher> teacherRepository;

        public TeacherPageController(ISchoolRepository<Teacher> teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public IActionResult Index()
        {
            var session = HttpContext.Session.GetInt32("userNumber");
            var teacher = teacherRepository.find(session.Value);
            return View(teacher);
            
        }
    }
}
