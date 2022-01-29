using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Models.repository
{
    public class NewsRepository : ISchoolRepository<News>
    {
        IList<News> News;
        public NewsRepository()
        {
            News = new List<News>()
            {
                new News{Name = "School Bus", ImageUrl = ""}
            };
        }
        public void Add(News intity)
        {
            News.Add(intity);
        }

        public void Delete(int Id)
        {
            var news = find(Id);
            News.Remove(news);
        }

        public News find(long Id)
        {
            var news = News.SingleOrDefault(n => n.Id == Id);
            return news;
        }

        public News findEntity(int id)
        {
            throw new NotImplementedException();
        }

        public IList<News> List()
        {
            return News;
        }

        public void Update(int Id, News intity)
        {
            var news = find(Id);
            news.Name = intity.Name;
            news.ImageUrl = intity.ImageUrl;
        }
    }
}
