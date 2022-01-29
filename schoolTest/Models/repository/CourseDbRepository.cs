using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class CourseDbRepository : ISchoolRepository<Course>
    {

        schoolTestDbContext db;
        public CourseDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(Course intity)
        {
           
            db.Courses.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            
            var course = findEntity(Id);
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public Course find(Int64 Id)
        {
            //var course = db.Courses.SingleOrDefault(c => c.courseId == Id);
            //return course;
            var course = db.Courses.Include(a => a.teacher).SingleOrDefault(b => b.courseId == Id);
            return course;
        }

        public Course findEntity(int id)
        {
            Course course = db.Courses.Include(a => a.teacher).SingleOrDefault(b => b.courseId == id);
            return course;
        }

        public IList<Course> List()
        {
            
            return db.Courses.Include(a => a.teacher).ToList();
        }

        public void Update(int Id, Course intity)
        {
            //var course = find(Id);
            //course.courseName = intity.courseName;
            //course.maxMark = intity.maxMark;
            //course.minMark = intity.minMark;
            //course.teacher = intity.teacher;
            db.Update(intity);
            db.SaveChanges();

        }
    }
}