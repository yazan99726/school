using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class EnrollmentRepository : ISchoolRepository<Enrollment>
    {
        IList<Enrollment> Enrollment;
        public EnrollmentRepository()
        {
            Enrollment = new List<Enrollment>()
            {
                new Enrollment{enrollmentId = 1, startTime = "10:00", endTime= "11:00", enrollCourse = new Course(), enrollStudent = new Student(), semester = 1, year = 2007 },
                new Enrollment{enrollmentId = 2, startTime = "11:00", endTime= "12:00", enrollCourse = new Course(), enrollStudent = new Student(), semester = 1, year = 2007 },
                new Enrollment{enrollmentId = 3, startTime = "12:00", endTime= "01:00", enrollCourse = new Course(), enrollStudent = new Student(), semester = 2, year = 2007 },
            };
        }
        public void Add(Enrollment intity)
        {
            intity.enrollmentId = Enrollment.Max(e => e.enrollmentId) + 1;
            Enrollment.Add(intity);
        }

        public void Delete(int Id)
        {
            var enroll = findEntity(Id);
            Enrollment.Remove(enroll);
        }

        public Enrollment find(long Id)
        {
            var enroll = Enrollment.SingleOrDefault(e => e.enrollmentId == Id);
            return enroll;

        }


        public Enrollment findEntity(int id)
        {
            var enroll = Enrollment.SingleOrDefault(e => e.enrollmentId == id);
            return enroll;
        }

        public IList<Enrollment> List()
        {
            return Enrollment;
        }

        public void Update(int Id, Enrollment intity)
        {
            var enroll = findEntity(Id);
            enroll.startTime = intity.startTime;
            enroll.endTime = intity.endTime;
            enroll.semester = intity.semester;
            enroll.year = intity.year;
            enroll.enrollCourse = intity.enrollCourse;
            enroll.enrollStudent = intity.enrollStudent;
            
        }
    }
}
