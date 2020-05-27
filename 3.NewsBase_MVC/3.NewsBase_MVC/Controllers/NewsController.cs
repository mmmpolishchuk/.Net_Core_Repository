using _3.NewsBase_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3.NewsBase_MVC.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            ViewData["news"] = NewsBase.News;
            return View();
        }
    }
}