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
       
        public decimal ?Rating { get; set; }
        public ICollection<Meal>? Meal { get; set; } = new HashSet<Meal>();

    }
}
