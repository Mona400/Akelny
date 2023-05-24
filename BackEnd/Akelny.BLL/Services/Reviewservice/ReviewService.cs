using Akelny.BLL.Dto.ReviewDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;

namespace Akelny.BLL.Services.Reviewservice;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    void IReviewService.Add(ReviewToAddDto reviewDto)
    {
        var review = new Review
        {
            Comment = reviewDto.Comment,
            Impression = reviewDto.Impression,
            UserName = reviewDto.UserName,
            RestId = reviewDto.RestId,
            UserId = reviewDto.UserId,
            TimeCreated = reviewDto.TimeCreated,

        };
        _unitOfWork.ReviewRepo.Add(review);
        _unitOfWork.ReviewRepo.SaveChanges();

    }

    int? IReviewService.Delete(int id)
    {
        Review? review = _unitOfWork.ReviewRepo.GetById(id);
        if (review == null)
        {
            return null;
        }

        _unitOfWork.ReviewRepo.Delete(review);
        _unitOfWork.ReviewRepo.SaveChanges();
        return review.Id;
    }

    int? IReviewService.Edit(int id, ReviewToEditdto reviewToEditdto)
    {
        Review? review = _unitOfWork.ReviewRepo.GetById(id);
        if (review == null)
        {
            return null;
        }
        review.Impression = reviewToEditdto.Impression;
        review.Comment = reviewToEditdto.Comment;

        _unitOfWork.ReviewRepo.Update(review);
        _unitOfWork.ReviewRepo.SaveChanges();
        return review.Id;
    }

    List<ReviewDto> IReviewService.GetAll()
    {
        List<Review> reviewList = _unitOfWork.ReviewRepo.GetAll();
        return reviewList.Select(r => new ReviewDto
        {
            Comment = r.Comment,
            Id = r.Id,
            Impression = r.Impression,
            RestId = r.RestId,
            TimeCreated = r.TimeCreated,
            UserId = r.UserId,
            UserName = r.UserName,
        }).ToList();
    }

    ReviewDto? IReviewService.GetById(int id)
    {
        Review? review = _unitOfWork.ReviewRepo.GetById(id);
        if (review == null) { return null; }
        if (review.Id != id) { return null; }
        var reviewDto = new ReviewDto();
        reviewDto.Id = review.Id;
        reviewDto.TimeCreated = review.TimeCreated;
        reviewDto.UserId = review.UserId;
        reviewDto.UserName = review.UserName;
        reviewDto.Comment = review.Comment;
        reviewDto.RestId = review.RestId;
        reviewDto.Impression = review.Impression;
        return reviewDto;

    }
}
