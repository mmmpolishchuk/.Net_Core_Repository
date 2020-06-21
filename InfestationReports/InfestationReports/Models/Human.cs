using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfestationReports.Models
{
    public class Human
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$",
            ErrorMessage = "First name value is incorrect! It must contains up only letters")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$",
            ErrorMessage = "Last name value is incorrect! It must contains up only letters")]
        public string LastName { get; set; }

        [Range(1, 150, ErrorMessage = "Age value is not valid")]
        public int Age { get; set; }

        [Required] public bool IsSick { get; set; }
        [Required] public string Gender { get; set; }

        [Range(1, 4, ErrorMessage = "Id is not valid, retry input")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual List<News> News { get; set; }
    }
}