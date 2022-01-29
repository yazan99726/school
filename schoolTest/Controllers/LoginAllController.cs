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
    public class LoginAllController : Controller
    {
        private readonly ISchoolRepository<LoginAll> loginAllRepository;
        private readonly ISchoolRepository<Student> studentRepository;
        private readonly ISchoolRepository<Teacher> teacherRepository;

        public LoginAllController(ISchoolRepository<LoginAll> loginAllRepository, ISchoolRepository<Student> studentRepository, ISchoolRepository<Teacher> teacherRepository) 
        {
            this.loginAllRepository = loginAllRepository;
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
        }
        public IActionResult Index()
        {
            var log = loginAllRepository.List();
            return View(log);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginAllViewModel model)
        {
            try
            {
                if (model.Password != "")
                {
                    //var checkTid = teacherRepository.find(model.UserNumber);
                    if (model.UserNumber.ToString().Length == 6)
                    {
                        var checkTeacher = loginAllRepository.find(model.UserNumber);
                        if (checkTeacher != null)
                        {
                            return ViewBag.message = "this User acssist";
                        }
                        else
                        {
                            var teacher = teacherRepository.find(model.UserNumber);
                            if (teacher != null)
                            {
                                LoginAll loginAll = new LoginAll
                                {
                                    Id = model.id,
                                    //UserNumber = teacher.teacherId,
                                    UserNumber = model.UserNumber,
                                    Password = model.Password,
                                    confirmPass = model.confirmPass,
                                };
                                loginAllRepository.Add(loginAll);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                                ViewBag.message = "Register Failed";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                         if (model.UserNumber.ToString().Length == 4)
                    {
                        var check = loginAllRepository.find(model.UserNumber);
                        if (check != null)
                        {
                            //return ViewBag.message = "this User acssist";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            var student = studentRepository.find(model.UserNumber);
                            if (student != null)
                            {
                                LoginAll loginAll = new LoginAll
                                {
                                    Id = model.id,
                                    UserNumber = student.student_Id,
                                    Password = model.Password,
                                    confirmPass = model.confirmPass,
                                };
                                loginAllRepository.Add(loginAll);
                                return RedirectToAction("Index", "StudentPage");
                            }
                            else
                                ViewBag.message = "Register Failed";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ViewBag.message = "Enter UserNumber correct";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                 
               
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Verify()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Verify(LoginAll loginAll)
        {


           

                var login = loginAllRepository.List();

                var userNum = login.Where(u => u.UserNumber.Equals(loginAll.UserNumber));

                var pass = userNum.Where(p => p.Password.Equals(loginAll.Password));

                if (pass.Count() == 1)
                {
                    HttpContext.Session.SetInt32("userNumber", loginAll.UserNumber);
                    if (loginAll.UserNumber.ToString().Length == 6)
                    {
                        HttpContext.Session.SetInt32("userNumber", loginAll.UserNumber);
                        return RedirectToAction("Index", "TeacherPage");

                    }
                    else if (loginAll.UserNumber.ToString().Length == 4)
                    {
                        HttpContext.Session.SetInt32("userNumber", loginAll.UserNumber);
                        return RedirectToAction("Index", "StudentPage", "id");
                    }
                    
                    else if (loginAll.UserNumber.ToString().Length == 8)
                    {
                    HttpContext.Session.SetInt32("userNumber", loginAll.UserNumber);
                    return RedirectToAction("Index", "ControlPanel");
                    }
                    else
                    {
                        ViewBag.message = "Login Failed";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.message = "Login Failed";
                    return RedirectToAction("Index", "Home");
                }
           

        }
        [Route("logout")]
        public IActionResult Logout()
        {
            //FormsAuthentication.SignOut();
            //Session.Abandon(); 

            //HttpContext.Session.GetInt32("userNumber");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}

