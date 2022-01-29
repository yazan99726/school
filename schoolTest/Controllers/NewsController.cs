using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolTest.Models;
using schoolTest.Models.repository;
using schoolTest.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace schoolTest.Controllers
{
    public class NewsController : Controller
    {
        private readonly ISchoolRepository<News> newsRepository;
        private readonly IHostingEnvironment hosting;

        public NewsController(ISchoolRepository<News> newsRepository, IHostingEnvironment hosting)
        {
            this.newsRepository = newsRepository;
            this.hosting = hosting;
        }
        // GET: NewsController
        public ActionResult Index()
        {
            var news = newsRepository.List();
            return View(news);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            var news = newsRepository.find(id);
            return View(news);
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsViewModel model)
        {
            try
            {
                
                string fileName = Uploadfile(model.File) ?? string.Empty;
                model.ImageUrl = fileName;
                
                News news1 = new News
                {
                    Id = model.Id,
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                };
                newsRepository.Add(news1);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            var news = newsRepository.find(id);
            return View(news);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, News news)
        {
            try
            {
                News news1 = new News
                {
                    Id = news.Id,
                    Name = news.Name,
                    ImageUrl = news.ImageUrl,
                };
                newsRepository.Update(news.Id, news1);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            var news = newsRepository.find(id);
            return View(news);
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, News news)
        {
            try
            {
                newsRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        string Uploadfile(IFormFile file)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "images");
                string fullPath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(fullPath, FileMode.Create));
                return file.FileName;
            }
            return null;
        }
    }
}
