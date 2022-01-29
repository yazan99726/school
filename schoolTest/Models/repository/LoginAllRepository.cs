using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class LoginAllRepository : ISchoolRepository<LoginAll>
    {
        IList<LoginAll> loginAlls;
        public LoginAllRepository()
        {
            loginAlls = new List<LoginAll>()
            {
                new LoginAll{Id = 1, UserNumber = 0, Password = "123", confirmPass="123"},
                new LoginAll{Id = 2, UserNumber = 0, Password = "123", confirmPass="123"},
                new LoginAll{Id = 3, UserNumber = 0, Password = "123", confirmPass="123"},
            };
        }
        public void Add(LoginAll intity)
        {
            intity.Id = loginAlls.Max(i => i.Id) + 1;
            loginAlls.Add(intity);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public LoginAll find(long Id)
        {
            var log = loginAlls.SingleOrDefault(l => l.UserNumber == Id);
            return log;
        }

        public LoginAll findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LoginAll> List()
        {
            return loginAlls;
        }

        public void Update(int Id, LoginAll intity)
        {
            throw new NotImplementedException();
        }
    }
}
