using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class StudentRepository : ISchoolRepository<Student>
    {
        IList<Student> students;
        public StudentRepository()
        {
            students = new List<Student>
            {
                new Student{student_Id= 1111, FName="yazan", SName="tayem", GuardianPhone="0786477653" },
                new Student{student_Id = 2222, FName="ahmad", SName = "tayem", GuardianPhone = "0785188173"},
                //new Student{student_Id = 333333, FName="ahmad", SName = "tayem", GuardianPhone = "0785188173"},

            };
        }
        public void Add(Student intity)
        {
            students.Add(intity);
        }

        public void Delete(int Id)
        {
            var student = find(Id);
            students.Remove(student);
        }

        public Student find(Int64 Id)
        {
            var student = students.SingleOrDefault(s => s.student_Id == Id);
            return student;
        }

        public Student findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Student> List()
        {
            return students;
        }

        public void Update(int Id, Student intity)
        {
            var student = find(Id);
            student.FName = intity.FName;
            student.SName = intity.SName;
            student.TName = intity.TName;
            student.LName = intity.LName;
            student.birthDate = intity.birthDate;
            student.city = intity.city;
            student.street = intity.street;
            student.state = intity.state;
            student.build_No = intity.build_No;
            student.GuardianPhone = intity.GuardianPhone;
        }
    }
}
