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
    public class StudentController : Controller
    {
        private ISchoolRepository<Student> studentRepository;
        //private readonly IBookRepository<Author> authorrepository;
        //private readonly HostingEnvironment hosting;
        public StudentController(ISchoolRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
            

        }
        // GET: StudentController
        public ActionResult Index()
        {
            var student = studentRepository.List();
            return View(student);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            id =Convert.ToInt32( HttpContext.Session.GetInt32("userNumber"));
            var student = studentRepository.find(id);

            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student newStudent)
        {
            try
            {
                //Student student = new Student
                //{
                //    student_Id = newStudent.student_Id,
                //    FName = newStudent.FName,
                //    SName = newStudent.SName,
                //    TName = newStudent.TName,
                //    LName = newStudent.LName,
                //    birthDate = newStudent.birthDate,
                //    city = newStudent.city,
                //    street = newStudent.street,
                //    state = newStudent.state,
                //    build_No = newStudent.build_No,
                //    GuardianPhone = newStudent.GuardianPhone,
                //};
                newStudent.birthDate = DateTime.Now;
                studentRepository.Add(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = studentRepository.find(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                Student student1 = new Student
                {
                    
                    student_Id = student.student_Id,
                    FName = student.FName,
                    SName = student.SName,
                    TName = student.TName,
                    LName = student.LName,
                    birthDate = student.birthDate,
                    city = student.city,
                    state = student.state,
                    street = student.street,
                    build_No = student.build_No,
                    GuardianPhone = student.GuardianPhone
                };
                studentRepository.Update(id, student1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = studentRepository.find(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                studentRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
