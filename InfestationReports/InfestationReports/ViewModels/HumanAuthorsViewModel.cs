using System.Collections.Generic;
using InfestationReports.Models;

namespace InfestationReports.ViewModels
{
    public class HumanAuthorsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NewsCount { get; set; }
        public List<News> News { get; set; }
    }
}