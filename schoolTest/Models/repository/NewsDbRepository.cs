using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class NewsDbRepository : ISchoolRepository<News>
    {
        schoolTestDbContext db;
        public NewsDbRepository(schoolTestDbContext _db)
        {
            db = _db;
        }
        public void Add(News intity)
        {
            db.News.Add(intity);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var news = find(Id);
            db.News.Remove(news);
        }

        public News find(long Id)
        {
            var news = db.News.SingleOrDefault(n => n.Id == Id);
            return news;
        }

        public News findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<News> List()
        {
            return db.News.ToList();
        }

        public void Update(int Id, News intity)
        {
            var news = find(Id);
            news.Name = intity.Name;
            news.ImageUrl = intity.ImageUrl;
        }
    }
}