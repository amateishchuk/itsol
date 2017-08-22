using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItSolutionExpert.DataAccessLayer.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(31, MinimumLength = 3)]
        public string Name { get; set; }
        public  ICollection<Item> Items { get; set; }

        public Category()
        {
            Items = new List<Item>();
        }
    }
}
