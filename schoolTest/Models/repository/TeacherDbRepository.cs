using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class TeacherDbRepository : ISchoolRepository<Teacher>
    {
        schoolTestDbContext db;
        public TeacherDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(Teacher intity)
        {
            
            db.Teachers.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var teacher = find(Id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
        }

        public Teacher find(Int64 Id)
        {
            var teacher = db.Teachers.SingleOrDefault(a => a.teacherId == Id);
            return teacher;
        }

        public Teacher findEntity(int id)
        {
            var teacher = db.Teachers.SingleOrDefault(a => a.teacherId == id);
            return teacher;
        }

        public IList<Teacher> List()
        {
            return db.Teachers.ToList();
        }

        public void Update(int Id, Teacher intity)
        {
            //var teacher = find(Id);
            //teacher.fname = intity.fname;
            //teacher.sname = intity.sname;
            //teacher.tname = intity.tname;
            //teacher.lname = intity.lname;
            //teacher.phone = intity.phone;
            //teacher.ssn = intity.ssn;
            //author.Imageurl = intity.Imageurl;
            db.Update(intity);
            db.SaveChanges();
        }
    }
}

