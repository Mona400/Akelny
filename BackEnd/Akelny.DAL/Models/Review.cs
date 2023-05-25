using System.ComponentModel.DataAnnotations.Schema;

namespace Akelny.DAL.Models;

public class Review
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    [ForeignKey("User")]
    public string UserId { get; set; } = string.Empty;
    [ForeignKey("Restaurant")]
    public int RestId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string Impression { get; set; } = string.Empty;

    public DateTime TimeCreated { get; set; }

}
