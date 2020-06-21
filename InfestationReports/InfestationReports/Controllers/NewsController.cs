using System.Linq;
using InfestationReports.Models;
using InfestationReports.Models.Repositories.HumanRepository;
using InfestationReports.Models.Repositories.NewsRepository;
using Microsoft.AspNetCore.Mvc;

namespace InfestationReports.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _repositoryNews;
        private IHumanRepository _repositoryHuman;

        public NewsController(INewsRepository repositoryNews, IHumanRepository repositoryHuman)
        {
            _repositoryNews = repositoryNews;
            _repositoryHuman = repositoryHuman;
        }

        public IActionResult Index(int newsId)
        {
            var author = _repositoryHuman.GetAllHumans().ToList();

            if (newsId == 0)
            {
                var news = _repositoryNews.GetAllNews().AsEnumerable();
                return View(news);
            }
            else
            {
                var singleNews = _repositoryNews.GetAllNews().Where(news => news.Id == newsId);
                return View(singleNews);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(News news)
        {
           news.Author = _repositoryHuman.GetAllHumans().ToList().FirstOrDefault(author => author.Id == news.AuthorId);

            if (ModelState.IsValid)
            {
                _repositoryNews.CreateNews(news);
                return View("Index", _repositoryNews.GetAllNews());

            }

            return View();
        }
    }
}