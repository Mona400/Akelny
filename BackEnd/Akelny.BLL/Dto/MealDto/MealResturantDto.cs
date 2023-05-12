using Akelny.BLL.Dto.ResturantsDto;
using Akelny.BLL.Dto.SectionsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.MealDto
{
    public class MealResturantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Image { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public ResturantDto Restaurant { get; set; }
        public SectionDto Section { get; set; }
    }
}
