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
    public class MarksController : Controller
    {
        private readonly ISchoolRepository<Marks> marksRepository;
        private readonly ISchoolRepository<Student> studentrepository;
        private readonly ISchoolRepository<Course> courserepository;

        public MarksController(ISchoolRepository<Marks> marksRepository, ISchoolRepository<Student> studentrepository, ISchoolRepository<Course> courserepository)
        {
            this.marksRepository = marksRepository;
            this.studentrepository = studentrepository;
            this.courserepository = courserepository;
        }
        // GET: MarksController
        public ActionResult Index()
        {
            var marks = marksRepository.List();
            return View(marks);
        }

        // GET: MarksController/Details/5
        public ActionResult Details(int id)
        {
            //id = Convert.ToInt32(HttpContext.Session.GetInt32("userNumber"));
            //var mark = marksRepository.List().Where(m=>m.student.student_Id==id);
            //return View(mark);
            var Id = Convert.ToInt32(HttpContext.Session.GetInt32("userNumber"));
            if (Id.ToString().Length == 4)
            {
                var marks = marksRepository.List().Where(i=>i.student.student_Id==Id);
                return View(marks);
            }
            else
            {
                if (Id.ToString().Length == 6)
                {
                    var marks = marksRepository.List().Where(i => i.course.teacher.teacherId == Id);
                    return View(marks);
                }
                else return View();

            }
        }

        // GET: MarksController/Create
        public ActionResult Create()
        {
            var model = new MarksCourseViewModel
            {
                Students = GetAllStudent().Students,
                Courses = GetAllCourse().Courses,
                //Students = studentRepository.List().ToList(),
                
            };
            return View(model);

        }

        // POST: MarksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarksCourseViewModel model)
        {
            try
            {

                //var studeent = studentRepository.find(model.studentId);
                //var course = courseRepository.find(model.courseId);
                model.Courses = courserepository.List().ToList();
                model.Students = studentrepository.List().ToList();
                Marks marks = new Marks
                {
                    Id = model.id,
                    student = studentrepository.find(model.studentId),
                    course = courserepository.find(model.courseId),
                    FinalEx = model.FinalEx,
                    FirstEx = model.FirstEx,
                    SecondEx = model.SecondEx,
                    Participation = model.Participation,
                    TotalMark = model.TotalMark, 
                    Status = model.Status,
                };
               
                marksRepository.Add(marks);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //return View(GetAllStudent());
        }

        // GET: MarksController/Edit/5
        public ActionResult Edit(int id)
        {

            var mark = marksRepository.find(id);
            var studentId = mark == null ? mark.student.student_Id = 0 : mark.student.student_Id;
            var marks = marksRepository.findEntity(id);
            var courseid = marks == null ? marks.course.courseId = 0 : marks.course.courseId;
            //var mark = marksRepository.find(id);

            //var studentId = mark == null ? mark.student.student_Id = 0 : mark.student.student_Id;
            //var courseid = mark == null ? mark.course.courseId = 0 : mark.course.courseId;
            var viewmodel = new MarksCourseViewModel
            {
                id = mark.Id,
                FirstEx = mark.FirstEx,
                SecondEx = mark.SecondEx,
                Participation = mark.Participation,
                FinalEx = mark.FinalEx,
                TotalMark = mark.TotalMark,
                Status = mark.Status,
                courseId = courseid,
                Courses = courserepository.List().ToList(),
                studentId = studentId,
                Students = studentrepository.List().ToList(),
                
            };
            return View(viewmodel);

        }

        // POST: MarksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MarksCourseViewModel model)
        {
            try
            {
                var studentid = studentrepository.find(model.studentId);
                var courseid = courserepository.find(model.courseId);
                
                Marks marks = new Marks()
                {
                    Id = model.id,
                    FirstEx = model.FirstEx,
                    SecondEx = model.SecondEx,
                    Participation = model.Participation,
                    FinalEx = model.FinalEx,
                    TotalMark = model.TotalMark,
                    Status = model.Status,
                    student = studentid,
                    course = courseid,
                    
                    

                };
                marksRepository.Update(model.id, marks);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: MarksController/Delete/5
        public ActionResult Delete(int id)
        {
            var mark = marksRepository.find(id);
            return View(mark);
        }

        // POST: MarksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Marks marks)
        {
            try
            {
                var mark = marksRepository.find(id);
                marksRepository.Delete(mark.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        List<Student> Fillselectlist()
        {
            var students = studentrepository.List().ToList();
            students.Insert(0, new Student { student_Id = -1, FName = "----  please enter Student ----" });
            return students;
        }
        MarksCourseViewModel GetAllStudent()
        {
            var model = new MarksCourseViewModel
            {
                Students = Fillselectlist()
            };
            return model;
        }

        List<Course> FillselectlistCourse()
        {
            var courses = courserepository.List().ToList();
            courses.Insert(0, new Course { courseId = -1, courseName = "----  please enter Course ----" });
            return courses;
        }
        MarksCourseViewModel GetAllCourse()
        {
            var model = new MarksCourseViewModel
            {
                Courses = FillselectlistCourse()
            };
            return model;
        }
    }
}
