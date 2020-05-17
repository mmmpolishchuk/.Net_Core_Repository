using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace _1.Introduction._Startup.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Index method from HomeController class was called.";
        }
    }
}
