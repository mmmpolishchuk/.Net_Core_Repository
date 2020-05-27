using Microsoft.AspNetCore.Mvc;

namespace _1.Introduction_StartupClass.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Index method from HomeController class was called.";
        }
    }
}
