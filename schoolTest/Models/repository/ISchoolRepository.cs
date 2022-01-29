using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public interface ISchoolRepository<TIntity>
    {
        IList<TIntity> List();
        TIntity find(Int64 Id);
        TIntity findEntity(int id);
        void Add(TIntity intity);
        void Update(int Id, TIntity intity);
        void Delete(int Id);

    }
}
