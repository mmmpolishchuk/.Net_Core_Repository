using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfestationReports.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The title is too short.")]
        [RegularExpression("[A-Za-z0-9 ]+", ErrorMessage = "Invalid format of title.")]
        public string Title { get; set; }

        [Required]
        [MinLength(15, ErrorMessage = "The text is too short, users want to know more...")]
        [RegularExpression("[A-Za-z0-9 -@]+", ErrorMessage ="Invalid format of text.")]
        public string Text { get; set; }

        [Required] public bool IsFake { get; set; }

        [Required] 
        [RegularExpression("^[1-9]+[0-9]*$", ErrorMessage ="The author's Id value is invalid. It should be only positive number.")]
        public int AuthorId { get; set; }
        public virtual Human Author { get; set; }
    }
}