using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.MealDto
{
    public class MealToEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Image { get; set; } = string.Empty;

        public decimal? Price { get; set; }
        //[ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        //public Restaurant? Restaurant { get; set; }
        //[ForeignKey("Section")]
        public int SectionId { get; set; }
        //public Section? Section { get; set; }
    }
}
