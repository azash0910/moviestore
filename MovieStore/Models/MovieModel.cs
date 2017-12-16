using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }


}