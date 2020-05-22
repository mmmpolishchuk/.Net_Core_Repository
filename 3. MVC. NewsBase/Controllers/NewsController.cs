using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasicInfo.Models;

namespace _3._MVC._NewsBase.Controllers
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