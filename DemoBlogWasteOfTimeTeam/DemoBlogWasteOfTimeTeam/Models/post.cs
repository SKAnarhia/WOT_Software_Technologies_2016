using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoBlogWasteOfTimeTeam.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }


        [StringLength(200)]
        public string Song { get; set; }

        public Category Category { get; set; }

        public string Video { get; set; }


        [Required]
        public DateTime Date { get; set; }

        public string Comment { get; set; }


        public ApplicationUser Author { get; set; }
    }
}