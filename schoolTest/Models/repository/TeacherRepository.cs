using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class TeacherRepository : ISchoolRepository<Teacher>
    {
        IList<Teacher> teachers;
        public TeacherRepository()
        {
            teachers = new List<Teacher>()
            {
                new Teacher{teacherId = 666666, fname = "mohammad", sname = "ibrahime", tname = "abed", lname="alramahi", phone="0798254625", ssn=1201},
                 new Teacher{teacherId = 555555, fname = "yazan", sname = "Ghaleb", tname = "mustafa", lname="tayem", phone="0786477653", ssn=1202}
            };
        }
        public void Add(Teacher intity)
        {
            intity.teacherId = teachers.Max(a => a.teacherId) + 1;
            teachers.Add(intity);
        }

        public void Delete(int Id)
        {
            var teacher = find(Id);
            teachers.Remove(teacher);
        }

        public Teacher find(Int64 Id)
        {
            var teacher = teachers.SingleOrDefault(a => a.teacherId == Id);
            return teacher;
        }

        public Teacher findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Teacher> List()
        {
            return teachers;
        }

        public void Update(int Id, Teacher intity)
        {
            var teacher = find(Id);
            teacher.fname = intity.fname;
            teacher.sname = intity.sname;
            teacher.tname = intity.tname;
            teacher.lname = intity.lname;
            teacher.phone = intity.phone;
            teacher.ssn = intity.ssn;
            //author.Imageurl = intity.Imageurl;
        }
    }
}
