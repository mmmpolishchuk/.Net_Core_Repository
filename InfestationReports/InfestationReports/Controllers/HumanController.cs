using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using InfestationReports.Models;
using InfestationReports.Models.Repositories.HumanRepository;
using InfestationReports.Models.Repositories.NewsRepository;
using InfestationReports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InfestationReports.Controllers
{
    public class HumanController : Controller
    {
        private InfestationContext _context;

        private IHumanRepository _humanRepository;

        public HumanController(InfestationContext context, IHumanRepository humanRepository)
        {
            _context = context;
            _humanRepository = humanRepository;
        }

        public IActionResult Country(string name)
        {
            var country = _context.Countries.SingleOrDefault(country => country.Name == name);

            if (country == null)
            {
                var errorMes = ViewBag.Error = name.ToUpper() + " not found";
                return View("Error", errorMes);
            }

            var humansByCountry =
                _context.Humans.Where(human => country.Id == human.CountryId).Select(human => human.Id).ToList();

            string _url = string.Format("/human/index?humansId=" + string.Join("&humansId=", humansByCountry));

            return Redirect(_url);
        }

        public IActionResult Index([FromQuery] List<int> humansId)
        {
            List<Human> people = new List<Human>();

            var countries = _context.Countries.ToList();

            if (humansId.Count == 0)
            {
                people = _humanRepository.GetAllHumans().ToList();
            }
            else
            {
                foreach (var hum in humansId)
                {
                    people.Add(_humanRepository.GetHuman(hum));
                }
            }
           HttpContext.Response.StatusCode = 418;
           return View(people);
        }

        public IActionResult Author([FromServices] INewsRepository newsRepository, int authorId)
        {
            var author = _humanRepository.GetAllHumans().FirstOrDefault(author => author.Id == authorId);
            var news = newsRepository.GetAllNews().ToList();

            var viewModel = new HumanAuthorsViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                NewsCount = news.Count(news => news.AuthorId == author.Id)
            };

            return View(viewModel);
        }

        public IActionResult News([FromServices] INewsRepository newsRepository, int authorId)
        {
            var author = _humanRepository.GetAllHumans().FirstOrDefault(author => author.Id == authorId);

            var newsByAuthor = newsRepository.GetAllNews().Where(news => news.Author == author).ToList();
            return View(newsByAuthor);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Human human)
        {
            if (ModelState.IsValid)
            {
                _humanRepository.CreateHuman(human);
                return View("Index", _humanRepository.GetAllHumans().ToList());
            }

            return View();
        }
    }
}