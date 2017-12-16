using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieStore.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }

    }
}