using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class CourseRepositpry : ISchoolRepository<Course>
    {
        IList<Course> courses;
        //private readonly TeacherRepository teacherRepository;
        //public List<Teacher> GetTeachers;
        public CourseRepositpry()
        {
            //this.teacherRepository = teacherRepository;
            //GetTeachers = teacherRepository.List().ToList();

            courses = new List<Course>()
            {
                new Course{courseId = 1, courseName = "math", minMark = 50, maxMark = 100, teacher = new Teacher()},
                new Course{courseId = 2, courseName = "english", minMark = 50, maxMark = 100, teacher = new Teacher()},
                new Course{courseId = 3, courseName = "arabic", minMark = 50, maxMark = 100, teacher = new Teacher()},
            };
        }
        public void Add(Course intity)
        {
            intity.courseId = courses.Max(e => e.courseId) + 1;
            courses.Add(intity);
        }

        public void Delete(int Id)
        {
            var course = findEntity(Id);
            courses.Remove(course);
        }

        public Course find(Int64 Id)
        {
            var course = courses.SingleOrDefault(c => c.courseId == Id);
            return course;
        }

        public Course findEntity(int id)
        {
            
            var course = courses.SingleOrDefault(e => e.courseId == id);
            return course;
        }

        public IList<Course> List()
        {
            return courses;
        }

        public void Update(int Id, Course intity)
        {
            var course = find(Id);
            course.courseName = intity.courseName;
            course.maxMark = intity.maxMark;
            course.minMark = intity.minMark;
            course.teacher = intity.teacher;
            
        }
    }
}
