using System.ComponentModel.DataAnnotations.Schema;

namespace Akelny.DAL.Models;

public class Cart
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public string? UserId { get; set; }

    public User? User { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal MonthlyPrice { get; set; }

    public string? Discount { get; set; }
    public ICollection<Meals_Dates>? Meals { get; set; }
    public PaymentDetails? PaymentDetails { get; set; }
}
