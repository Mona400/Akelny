using Akelny.BLL.Dto.MealDto;
using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.ResturantsDto;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.MealServices
{
    public interface IMealServices
    {
      
      
        List<MealDto> GetAll();
        List<MealDto> GetTopFourMeals();
        void AddMeal(MealToAddDto mealToAddDto);
        List<MealResturantDto> GetAllByResturantId(int? ResturantId);
        List<MealSectionDto> GetAllBySectionId(int? SectionId);
       MealDto? GetById(int id);
        void Delete(int id);
        void Edit(int id, MealToEditDto mealToEditDto);
    }
}
