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
    public class EnrollmentController : Controller
    {
        private readonly ISchoolRepository<Enrollment> enrollRepository;
        private readonly ISchoolRepository<Student> studentRepository;
        private readonly ISchoolRepository<Course> courseRepository;

        public EnrollmentController(ISchoolRepository<Enrollment> enrollRepository, ISchoolRepository<Student> studentRepository, ISchoolRepository<Course> courseRepository)
        {
            this.enrollRepository = enrollRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }
        // GET: EnrollmentController
        public ActionResult Index()
        {
            var enroll = enrollRepository.List();
            return View(enroll);
        }

        // GET: EnrollmentController/Details/5
        public ActionResult Details(int id)
        {
            //var enroll = enrollRepository.List().Where(m => m.enrollStudent.student_Id == id);
            var enroll = enrollRepository.find(id);
            
            return View(enroll);
        }

        // GET: EnrollmentController/Create
        public ActionResult Create()
        {
            var model = new EnrollmentViewModel
            {
                Courses = GetAllCourse().Courses,
                //Students = studentRepository.List().ToList(),
                Students = GetAllStudent().Students
            };
            return View(model);
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentViewModel model)
        {
            try
            {
                if (model.studentId == -1)
                {
                    ViewBag.message = "please inter Student from the list!";
                    var vmodel = new EnrollmentViewModel
                    {
                        Students = Fillselectlist()
                    };
                    return View(vmodel);
                }
                if (model.courseId == -1)
                {
                    ViewBag.message = "please inter Course from the list!";
                    var vmodel = new EnrollmentViewModel
                    {
                        Courses = FillselectlistCourse()
                    };
                    return View(vmodel);
                }
                //var studeent = studentRepository.find(model.studentId);
                //var course = courseRepository.find(model.courseId);
                
                Enrollment enrollment = new Enrollment
                {
                    enrollmentId = model.enrollmentId,
                    enrollStudent = studentRepository.find(model.studentId),
                    enrollCourse = courseRepository.find(model.courseId),
                    startTime = model.startTime,
                    endTime = model.endTime,
                    semester = model.semester,
                    year = model.year,
                };
                enrollRepository.Add(enrollment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //return View(GetAllStudent());
        }

        // GET: EnrollmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var enroll = enrollRepository.find(id);
            var studentId = enroll == null ? enroll.enrollStudent.student_Id = 0 : enroll.enrollStudent.student_Id;
            var enrol = enrollRepository.findEntity(id);
            var courseid = enroll == null ? enroll.enrollCourse.courseId = 0 : enroll.enrollCourse.courseId;
            var viewmodel = new EnrollmentViewModel
            {
                enrollmentId = enroll.enrollmentId,
                startTime = enroll.startTime,
                endTime = enroll.endTime,
                semester = enroll.semester,
                year = enroll.year,
                
                courseId = courseid,
                Courses = courseRepository.List().ToList(),
                studentId = studentId,
                Students = studentRepository.List().ToList(),

            };
            return View(viewmodel);
            
        }

        // POST: EnrollmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EnrollmentViewModel model)
        {
            try
            {
                var studentid = studentRepository.find(model.studentId);
                var courseid = courseRepository.find(model.courseId);
                Enrollment enroll = new Enrollment()
                {
                    enrollmentId = model.enrollmentId,
                    startTime = model.startTime,
                    endTime = model.endTime,
                    semester = model.semester,
                    year = model.year,
                    enrollStudent = studentRepository.find(model.studentId),
                    enrollCourse = courseRepository.find(model.courseId),
                    
                };
                enrollRepository.Update(id, enroll);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: EnrollmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var enroll = enrollRepository.findEntity(id);
            return View(enroll);
        }

        // POST: EnrollmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Enrollment enrollment)
        {
            try
            {
                
                enrollRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Table()
        {
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("userNumber"));
            if (id.ToString().Length==4)
            {
                var enroll = enrollRepository.List().Where(i => i.enrollStudent.student_Id == id);
                return View(enroll);
            }
            else
            {
                if (id.ToString().Length == 6)
                {
                    var enroll = enrollRepository.List().Where(i => i.enrollCourse.teacher.teacherId== id);
                    return View(enroll);
                }
                else return View();
                
            }
            
        }

        public ActionResult TableTeacher()
        {
            var id = Convert.ToInt32(HttpContext.Session.GetInt32("userNumber"));
            if (id.ToString().Length == 6)
            {
                var enroll = enrollRepository.List().Where(i => i.enrollCourse.teacher.teacherId == id);
                return View(enroll);
            }
            else return View();

            

        }
        List<Student> Fillselectlist()
        {
            var students = studentRepository.List().ToList();
            students.Insert(0, new Student { student_Id = -1, FName = "----  please enter Student ----" });
            return students;
        }
        EnrollmentViewModel GetAllStudent()
        {
            var model = new EnrollmentViewModel
            {
                Students = Fillselectlist()
            };
            return model;
        }

        List<Course> FillselectlistCourse()
        {
            var courses = courseRepository.List().ToList();
            courses.Insert(0, new Course { courseId = -1, courseName = "----  please enter courses ----" });
            return courses;
        }
        EnrollmentViewModel GetAllCourse()
        {
            var model = new EnrollmentViewModel
            {
                Courses = FillselectlistCourse()
            };
            return model;
        }
    }
}
