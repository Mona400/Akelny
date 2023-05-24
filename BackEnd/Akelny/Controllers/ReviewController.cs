using Akelny.BLL.Dto.ReviewDto;
using Akelny.BLL.Services.Reviewservice;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;

    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    [HttpGet]
    public ActionResult<List<ReviewDto>> GetAll()
    {
        return _reviewService.GetAll();

    }
    [HttpPost]
    public ActionResult Add(ReviewToAddDto reviewToAddDto)
    {
        _reviewService.Add(reviewToAddDto);
        return Ok("Review Added Successfully");
    }
    [HttpPut]
    [Route("{id:int}")]
    public ActionResult Edit(int id, ReviewToEditdto reviewToEditDto)
    {

        var review = _reviewService.Edit(id, reviewToEditDto);
        if (review is null) { return BadRequest(" Review Not Found"); }
        return Ok("Review updated successfully");

    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {

        var review = _reviewService.Delete(id);
        if (review is null) { return BadRequest(" Review Not Found"); }
        return Ok("Review deleted successfully");

    }

}
