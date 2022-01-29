using Microsoft.AspNetCore.Mvc;
using schoolTest.Models;
using schoolTest.Models.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Controllers
{
    public class ControlPanel : Controller
    {
        private readonly ISchoolRepository<Student> studentRepository;

        public ControlPanel(ISchoolRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var student = studentRepository.List();
            return View(student);
        }

    }
}
