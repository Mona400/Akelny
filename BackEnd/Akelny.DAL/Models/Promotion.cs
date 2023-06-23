using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
    public class Promotion { 
     public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime date { get; set; }

    public string ImageUrl { get; set; } = string.Empty;

    [Column(TypeName = "decimal(8,2)")]
    public decimal PriceBefore { get; set; }

    [Column(TypeName = "decimal(8,2)")]
    public decimal PriceAfter { get; set; }
    //[NotMapped]
    //public IFormFile? ImageFile { get; set; }


}
}
