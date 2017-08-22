using ItSolutionExpert.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItSolutionExpert.DataAccessLayer.EntityFramework
{
    public class ItemsDbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext dataContext)
        {
            dataContext.Categories.Add(new Category { Name = "Horror" });
            dataContext.Categories.Add(new Category { Name = "Comedy" });
            dataContext.Categories.Add(new Category { Name = "Drama" });
            dataContext.Categories.Add(new Category { Name = "Thriller" });

            base.Seed(dataContext);
        }
    }
}
