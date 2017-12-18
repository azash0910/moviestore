using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class RentMovieModel
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public bool Status { get; set; }
    }
}