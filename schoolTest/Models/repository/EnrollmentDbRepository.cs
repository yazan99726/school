using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace schoolTest.Models.repository
{
    public class EnrollmentDbRepository : ISchoolRepository<Enrollment>
    {
        schoolTestDbContext db;
        public EnrollmentDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(Enrollment intity)
        {
            
            db.Enrollments.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var enroll = findEntity(Id);
            db.Enrollments.Remove(enroll);
            db.SaveChanges();
        }

        public Enrollment find(long Id)
        {
            //var enroll = db.Enrollments.SingleOrDefault(e => e.enrollStudent.student_Id == Id);
            //return enroll;
            //var enroll = db.Enrollments.SingleOrDefault(b => b.enrollmentId == Id);
            //return enroll;
            Enrollment students = db.Enrollments.Include(a => a.enrollStudent).SingleOrDefault(b => b.enrollmentId == Id);
            

            return students;

        }


        public Enrollment findEntity(int id)
        {
            Enrollment enroll = db.Enrollments.Include(a => a.enrollCourse).SingleOrDefault(b => b.enrollmentId == id);
            return enroll;

        }

        public IList<Enrollment> List()
        {
            //return db.Enrollments.ToList();
            return db.Enrollments.Include(a => a.enrollStudent).Include(a => a.enrollCourse).Include(a => a.enrollCourse.teacher).ToList();
        }

        public void Update(int Id, Enrollment intity)
        {
            //var enroll = findEntity(Id);
            //enroll.startTime = intity.startTime;
            //enroll.endTime = intity.endTime;
            //enroll.semester = intity.semester;
            //enroll.year = intity.year;
            //enroll.enrollCourse = intity.enrollCourse;
            //enroll.enrollStudent = intity.enrollStudent;
            db.Update(intity);
            db.SaveChanges();

        }
    }
}
