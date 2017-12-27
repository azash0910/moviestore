using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class RentMovieViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        [UIHint("RentStatus")]
        public bool Status { get; set; }
        public string MovieName { get; set; }
        public string CustomerName { get; set; }
    }
}