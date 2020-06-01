using System.Linq;
using InfestationReports.Models.Repositories;
using InfestationReports.Models.Repositories.NewsRepository;
using Microsoft.AspNetCore.Mvc;

namespace InfestationReports.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _repository { get; set; }

        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Index()
        {
            ViewData["allNews"] = _repository.GetAllNews();
            return View();
        }

        public IActionResult Show(int newsId)
        {
            ViewData["newsById"] = _repository.GetAllNews().SingleOrDefault(news => news.Id == newsId);
            return View();
        }
    }
}
