using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class MarksRepository : ISchoolRepository<Marks>
    {
        IList<Marks> Mark;
        public MarksRepository()
        {
            Mark = new List<Marks>
            {
                new Marks{FirstEx = 18, SecondEx = 16, Participation = 8, FinalEx = 40, TotalMark = 82, Status = 1, course = new Course(), student = new Student() },
                new Marks{FirstEx = 16, SecondEx = 15, Participation = 10, FinalEx = 48, TotalMark = 89, Status = 1, course = new Course(), student = new Student()},
                new Marks{FirstEx = 20, SecondEx = 20, Participation = 10, FinalEx = 40, TotalMark = 90, Status = 1, course = new Course(), student = new Student()},
            };
        }
        public void Add(Marks intity)
        {
            Mark.Add(intity);
        }

        public void Delete(int Id)
        {
            var mark = find(Id);
            Mark.Remove(mark);
        }

        public Marks find(long Id)
        {
            var mark = Mark.FirstOrDefault(m => m.Id==Id);
            return mark;
        }

        public Marks findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Marks> List()
        {
          
            return Mark;
        }



        public void Update(int Id, Marks intity)
        {
            var mark = find(Id);
            mark.FirstEx = intity.FirstEx;
            mark.SecondEx = intity.SecondEx;
            mark.Participation = intity.Participation;
            mark.FinalEx = mark.FinalEx;
            mark.TotalMark = intity.TotalMark;
            mark.Status = intity.Status;
            mark.course = intity.course;
            mark.student = intity.student;
        }
    }
}
