using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using schoolTest.Models;
using schoolTest.Models.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ISchoolRepository<Teacher> teacherrepo;
       
        public TeacherController(ISchoolRepository<Teacher> teacherrepo)
        {
            this.teacherrepo = teacherrepo;
            
        }
        // GET: TeacherController
        public ActionResult Index()
        {
            var teachers = teacherrepo.List();
            return View(teachers);
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            id = Convert.ToInt32(HttpContext.Session.GetInt32("userNumber"));
            var teacher = teacherrepo.find(id);

            return View(teacher);
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                Teacher teacher1 = new Teacher
                {
                    
                    teacherId = teacher.teacherId,
                    fname = teacher.fname,
                    sname = teacher.sname,
                    tname = teacher.tname,
                    lname = teacher.lname,
                    phone = teacher.phone,
                    ssn = teacher.ssn
                    //Imageurl = filename
                };
                teacherrepo.Add(teacher1);
                return RedirectToAction(nameof(Index));
            
            }
            catch (Exception ex) // catches all exceptions
            {
                return View(ex.Message);
            }
            
        }
            
    

        // GET: TeacherController/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = teacherrepo.findEntity(id);
            return View(teacher);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Teacher teacher)
        {
            try
            {
                
                Teacher teacher1 = new Teacher
                {
                    
                    teacherId = teacher.teacherId,
                    fname = teacher.fname,
                    sname = teacher.sname,
                    tname = teacher.tname,
                    lname = teacher.lname,
                    phone = teacher.phone,
                    ssn = teacher.ssn,
                };
                teacherrepo.Update(id, teacher1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeacherController/Delete/5
        public ActionResult Delete(int id)
        {
            var teacher = teacherrepo.findEntity(id);
            return View(teacher);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Teacher teacher)
        {
            try
            {
                teacherrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
