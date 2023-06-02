using Akelny.BLL.Dto.ReviewDto;

namespace Akelny.BLL.Services.Reviewservice;

public interface IReviewService
{
    List<ReviewDto> GetAll();
    Task<bool> Add(ReviewToAddDto reviewDto);
    int? Edit(int id, ReviewToEditdto reviewToEditdto);
    int? Delete(int id);

    public ReviewDto? GetById(int id);
}
