using System.Linq;
using System.Net;
using InfestationReports.Models;
using InfestationReports.Models.Repositories;
using InfestationReports.Models.Repositories.HumanRepository;
using InfestationReports.Models.Repositories.NewsRepository;
using Microsoft.AspNetCore.Mvc;

namespace InfestationReports.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _repositoryNews { get; set; }
        private IHumanRepository _repositoryHuman { get; set; }

        public NewsController(INewsRepository repositoryNews, IHumanRepository repositoryHuman)
        {
            _repositoryNews = repositoryNews;
            _repositoryHuman = repositoryHuman;
        }

        public IActionResult Index()
        {
            var news = _repositoryNews.GetAllNews().ToList();
            var authors = _repositoryHuman.GetAllHumans().ToList();
            
            ViewData["allNews"] = news;
            return View();
        }

        public IActionResult Show(int newsId)
        {
            if (newsId <= _repositoryNews.GetAllNews().ToList().Count())
            {
                var news = _repositoryNews.GetAllNews().SingleOrDefault(news => news.Id == newsId);
                var author = _repositoryHuman.GetAllHumans().SingleOrDefault(author => news.AuthorId == author.Id);
                var getNews = author.News.SingleOrDefault(news => news.Id == newsId);
                ViewData["newsById"] = getNews;
            }
            else
            {
                const string result = "Oooops... There is no news with such ID.";
                ViewData["newsById"] = result;
            }
            return View();
        }
    }
}
