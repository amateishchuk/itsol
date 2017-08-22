using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItSolutionExpert.DataAccessLayer.Entities
{
    public class Item
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [StringLength(31)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]        
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        public Item()
        {
            Categories = new List<Category>();
        }
    }
}
