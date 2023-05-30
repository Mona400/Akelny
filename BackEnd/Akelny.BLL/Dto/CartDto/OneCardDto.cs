using Akelny.BLL.Dto.SubDto;
using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.CartDto;

public class OneCardDto
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public decimal MonthlyPrice { get; set; }
    public string Discount { get; set; } = string.Empty;
    public ICollection<MealsAndDatesDto>? Meals { get; set; }
    public PaymentDetails? PaymentDetails { get; set; }
}
