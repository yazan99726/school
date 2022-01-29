using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class MarksDbRepository : ISchoolRepository<Marks>
    {
        schoolTestDbContext db;
        public MarksDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(Marks intity)
        {
            db.Marks.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var mark = find(Id);
            db.Marks.Remove(mark);
            db.SaveChanges();
        }

        public Marks find(long Id)
        {
            Marks students = db.Marks.Include(a => a.student).Include(x=>x.course).SingleOrDefault(b => b.Id == Id);


            return students;
        }

        public Marks findEntity(int id)
        {
            Marks courses = db.Marks.Include(a => a.course).SingleOrDefault(b => b.Id == id);
            return courses;
        }

        public IList<Marks> List()
        {

            return db.Marks.Include(a => a.student).Include(a=>a.course).ToList();

        }
        


        public void Update(int Id, Marks intity)
        {
            //var mark = find(Id);
            //mark.FirstEx = intity.FirstEx;
            //mark.SecondEx = intity.SecondEx;
            //mark.Participation = intity.Participation;
            //mark.FinalEx = mark.FinalEx;
            //mark.TotalMark = intity.TotalMark;
            //mark.Status = intity.Status;
            //mark.course = intity.course;
            //mark.student = intity.student;
            db.Update(intity);
            db.SaveChanges();
        }
    }
}