using System;
using System.Collections.Generic;
using System.Linq;
using InfestationReports.Models;
using InfestationReports.Models.Repositories.HumanRepository;
using InfestationReports.Models.Repositories.NewsRepository;
using InfestationReports.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index(int humanId)
        {
            if (humanId == 0)
            {
                var people = _humanRepository.GetAllHumans().ToList();
                return View(people);
            }
            else
            {
                var human = _humanRepository.GetHuman(id: humanId);
                return View(human);
            }
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

        public IActionResult Country(string name)
        {
            var country = _context.Countries.SingleOrDefault(country => country.Name == name);

            var humansByCountry = _context.Humans.Where(human => country.Id == human.CountryId).ToList();
            return View(humansByCountry);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string FirstName, string LastName, int Age, bool IsSick, string Gender,
            int CountryId)
        {
            Human human = new Human();
            human.FirstName = FirstName;
            human.LastName = LastName;
            human.Age = Age;
            human.IsSick = IsSick;
            human.Gender = Gender;
            human.CountryId = CountryId;
            _humanRepository.CreateHuman(human);
            return View("Index", _humanRepository.GetAllHumans().ToList());
        }
    }
}