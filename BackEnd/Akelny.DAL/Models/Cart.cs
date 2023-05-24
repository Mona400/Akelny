using System.ComponentModel.DataAnnotations.Schema;

namespace Akelny.DAL.Models;

public class Cart
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public decimal MonthlyPrice { get; set; }

    public string Discount { get; set; } = string.Empty;
    public ICollection<Meals_Dates>? Meals { get; set; }
    public PaymentDetails? PaymentDetails { get; set; }
}
