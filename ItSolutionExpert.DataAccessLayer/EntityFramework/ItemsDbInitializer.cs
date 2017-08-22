using ItSolutionExpert.DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace ItSolutionExpert.DataAccessLayer.EntityFramework
{
    public class ItemsDbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext dataContext)
        {
            var horror = new Category { Name = "Horror" };
            var comedy = new Category { Name = "Comedy" };
            var drama = new Category { Name = "Drama" };
            var thriller = new Category { Name = "Thriller" };

            dataContext.Categories.Add(horror);
            dataContext.Categories.Add(comedy);
            dataContext.Categories.Add(drama);
            dataContext.Categories.Add(thriller);

            dataContext.SaveChanges();

            var item = new Item
            {
                Name = "film",
                Description = "About",
                Url = "http://kinopoisk.com/about",
                Categories = new List<Category> { horror, comedy, drama }
            };
            dataContext.Items.Add(item);

            dataContext.SaveChanges();

            base.Seed(dataContext);
        }
    }
}
