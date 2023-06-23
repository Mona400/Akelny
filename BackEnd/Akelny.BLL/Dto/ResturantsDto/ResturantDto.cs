

using Akelny.BLL.Dto.MealDto;

namespace Akelny.BLL.Dto.ResturantsDto
{
    public class ResturantDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public decimal? Rating { get; set; }
        //public int MealId { get; set; }
        public ICollection<MealDto.MealDto>? Meal { get; set; } 

        public ICollection<ReviewDto.ReviewDto>? Reviews { get; set; }

    }
}
