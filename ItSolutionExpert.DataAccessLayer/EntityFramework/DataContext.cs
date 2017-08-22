using ItSolutionExpert.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItSolutionExpert.DataAccessLayer.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnectionString") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
