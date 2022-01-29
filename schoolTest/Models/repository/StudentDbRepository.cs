using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class StudentDbRepository : ISchoolRepository<Student>
    {
        schoolTestDbContext db;
        public StudentDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(Student intity)
        {
            db.Students.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var student = find(Id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        public Student find(Int64 Id)
        {
            var student = db.Students.SingleOrDefault(s => s.student_Id == Id);
            return student;
        }

        public Student findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Student> List()
        {
            return db.Students.ToList();
        }

        public void Update(int Id, Student intity)
        {
            //var student = find(Id);
            //student.FName = intity.FName;
            //student.SName = intity.SName;
            //student.TName = intity.TName;
            //student.LName = intity.LName;
            //student.birthDate = intity.birthDate;
            //student.city = intity.city;
            //student.street = intity.street;
            //student.state = intity.state;
            //student.build_No = intity.build_No;
            //student.GuardianPhone = intity.GuardianPhone;
            db.Update(intity);
            db.SaveChanges();
            
        }
    }
}