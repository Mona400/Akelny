using System.ComponentModel.DataAnnotations;

namespace Akelny.DAL.Models;

public class PaymentDetails
{
    [Key]
    public string VisaNumber { get; set; } = string.Empty;
    public int CardVerificationValue { get; set; }
    public string HolderName { get; set; } = string.Empty;
    public string VisaExpirationDate { get; set; } = string.Empty;

}
