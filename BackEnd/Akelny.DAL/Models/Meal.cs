using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Image { get; set; } = string.Empty;
       
        public decimal? Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant ?Restaurant { get; set; }
        public int SectionId { get; set; }
        public Section ?Section { get; set; }
      
    }
}
