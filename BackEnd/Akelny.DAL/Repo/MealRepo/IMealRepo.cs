using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.MealRepo
{
    public interface IMealRepo:IGenericRepo<Meal>
    {
        List<Meal> GetAllByResturantId(int? ResturantId);
        List<Meal> GetAllBySectionId(int? SectionId);
       Meal? GetMealById(int? MealId);

    }
}
