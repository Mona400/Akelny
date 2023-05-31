using Akelny.BLL.Dto.SubDto;
using Akelny.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.CartDto
{
    public class CartToEditDto
    {
        [Column(TypeName = "decimal(9,2)")]
        public decimal MonthlyPrice { get; set; }

        public string Discount { get; set; } = string.Empty;
        public ICollection<MealsAndDatesDto>? Meals_dates { get; set; }
        public PaymentDetails? PaymentDetails { get; set; }
    }
}
