using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public int MealId { get; set; }
        public ICollection< Meal> ?Meals { get; set; }
        public ICollection<Restaurant>? Restaurant { get; set; }

    }
}
