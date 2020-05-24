using System.Linq;
using _3._MVC._NewsBase.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _3._MVC._NewsBase.Controllers
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
            ViewData["news"] = _repository.GetAllNews();
            return View();
        }

        public IActionResult Show(int newsId)
        {
            ViewData["news"] = _repository.GetAllNews().SingleOrDefault(news => news.Id == newsId);
            return View();
        }
    }
}
