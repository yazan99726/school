using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolTest.Models;
using schoolTest.Models.repository;
using schoolTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly ISchoolRepository<Course> courseRepository;
        private readonly ISchoolRepository<Teacher> teacherRepository;

        public CourseController(ISchoolRepository<Course> courseRepository, ISchoolRepository<Teacher> teacherRepository)
        {
            this.courseRepository = courseRepository;
            this.teacherRepository = teacherRepository;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var course = courseRepository.List();
            return View(course);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = courseRepository.find(id);
            return View(course);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            //var model = new CourseTeaherViewModel
            //{
            //    Teachers = teacherRepository.List().ToList()
            //};
            //return View(model);
            return View(GetAllTeacher());
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseTeaherViewModel model)
        {
            try
            {
                //var teacher = teacherRepository.find(model.teacherId);
                if (model.teacherId == -1)
                {
                    ViewBag.message = "please inter Teacher from the list!";
                    var vmodel = new CourseTeaherViewModel
                    {
                        Teachers = Fillselectlist()
                    };
                    return View(vmodel);
                }
                
                Course course = new Course
                {
                    courseId = model.courseId,
                    courseName = model.courseName,
                    maxMark = model.maxMark,
                    minMark = model.minMark,
                    teacher = teacherRepository.findEntity(model.teacherId),
                };
                courseRepository.Add(course);
                return RedirectToAction(nameof(Index));
            }
            
            catch
            {
                return View();
            }
            //ModelState.AddModelError("", "you have to fill all the required filled!");
            //return View(GetAllTeacher());
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var course = courseRepository.find(id);
            var teacherId = course.teacher == null ? course.teacher.teacherId = 0 : course.teacher.teacherId;
            //var teacherId = course.teacher.teacherId;

            var viewmodel = new CourseTeaherViewModel
            {
                courseId = course.courseId,
                courseName = course.courseName,
                maxMark = course.maxMark,
                minMark = course.minMark,
                teacherId = teacherId,
                Teachers = teacherRepository.List().ToList(),
                

            };
            return View(viewmodel);
            
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseTeaherViewModel model)
        {
            try
            {
                var teacher = teacherRepository.find(model.teacherId);
                Course course = new Course()
                {
                    courseId = model.courseId,
                    courseName = model.courseName,
                    maxMark = model.maxMark,
                    minMark = model.minMark,
                    teacher = teacher,
                    
                };
                courseRepository.Update(model.courseId, course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var course = courseRepository.find(id);
            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Course course)
        {
            try
            {
                courseRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        List<Teacher> Fillselectlist()
        {
            var teachers = teacherRepository.List().ToList();
            teachers.Insert(0, new Teacher { teacherId = -1, fname = "----  please enter Teacher ----" });
            return teachers;
        }
        CourseTeaherViewModel GetAllTeacher()
        {
            var model = new CourseTeaherViewModel
            {
                Teachers = Fillselectlist()
            };
            return model;
        }
    }
}
