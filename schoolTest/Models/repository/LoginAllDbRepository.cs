using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class LoginAllDbRepository : ISchoolRepository<LoginAll>
    {
        schoolTestDbContext db;
        public LoginAllDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(LoginAll intity)
        {
            
            db.LoginAlls.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public LoginAll find(long Id)
        {
            var log = db.LoginAlls.SingleOrDefault(l => l.UserNumber == Id);
            return log;
        }

        public LoginAll findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LoginAll> List()
        {
            return db.LoginAlls.ToList();
        }

        public void Update(int Id, LoginAll intity)
        {
            throw new NotImplementedException();
        }
    }
}