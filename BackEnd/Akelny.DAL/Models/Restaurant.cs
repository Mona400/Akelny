using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Description { get; set; } = string.Empty;
        //public string Image { get; set; }
        public string Speciality { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        public decimal ?Rating { get; set; }
        //public int MealId { get; set; }
        //public int SectionId { get; set; }
        public ICollection<Meal>? Meals { get; set; } = new HashSet<Meal>();
        public ICollection<Section>? Sections { get; set; } = new HashSet<Section>();

    }
}
