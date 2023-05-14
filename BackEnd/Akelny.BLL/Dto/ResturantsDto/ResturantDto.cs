using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.ResturantsDto
{
    public class ResturantDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        //public int MealId { get; set; }
        //public ICollection<Meal>? Meal { get; set; } = new HashSet<Meal>();

    }
}
