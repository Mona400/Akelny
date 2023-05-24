namespace Akelny.BLL.Dto.ReviewDto;

public class ReviewDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;

    public int UserId { get; set; }

    public int RestId { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string Impression { get; set; } = string.Empty;

    public DateTime TimeCreated { get; set; }
}
