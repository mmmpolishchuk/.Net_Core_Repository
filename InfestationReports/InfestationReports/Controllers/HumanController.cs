using System.Collections.Generic;
using System.Linq;
using System.Threading;
using InfestationReports.Models;
using InfestationReports.Models.Repositories.HumanRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace InfestationReports.Controllers
{
    public class HumanController : Controller
    {
        private InfestationContext _context { get; }
        private IHumanRepository _humanRepository { get; }
        public HumanController(InfestationContext context, IHumanRepository humanRepository)
        {
            _context = context;
            _humanRepository = humanRepository;
        }
        public IActionResult Index(int humanid)
        {
            if (humanid == 0)
            {
                ViewData["Human"] = _humanRepository.GetAllHumans().ToList();
            }
            else
            {
                ViewData["Human"] = _humanRepository.GetHuman(id: humanid);
            }
            return View();
        }

        public IActionResult Country(string name)
        {
            var country = _context.Countries.SingleOrDefault(country => country.Name == name);
            var humansByCountry = _context.Humans.Where(human => country.Id == human.CountryId).ToList();

            ViewData["getHumansByCountry"] = humansByCountry;
            return View();
        }
    }
}
