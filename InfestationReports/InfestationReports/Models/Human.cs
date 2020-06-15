using System.Collections.Generic;

namespace InfestationReports.Models
{
    public class Human
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsSick { get; set; }
        public string Gender { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<News> News { get; set; }
    }
}