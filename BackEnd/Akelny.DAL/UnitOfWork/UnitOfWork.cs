using Akelny.DAL.Repo.CartRepo;
using Akelny.DAL.Repo.MealRepo;
using Akelny.DAL.Repo.Meals_Dates_Repo;
using Akelny.DAL.Repo.PromotionRepo;
using Akelny.DAL.Repo.ResturantRepo;
using Akelny.DAL.Repo.ReviewRepo;
using Akelny.DAL.Repo.SectionRepo;
using Akelny.DAL.Repo.SubRepo;
using Akelny.DAL.Repo.UserRepo;
using Microsoft.AspNetCore.Http;

namespace Akelny.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPromotionRepo PromotionRepo { get; }
        public ISectionRepo SectionRepo { get; }
        public IMealRepo MealRepo { get; }
        public IResturantRepo ResturantRepo { get; }
        public ICartRepo CartRepo { get; }
        public ISubRepo Subrepo { get; }
        public IUserRepo UserRepo { get; }
        public IReviewRepo ReviewRepo { get; }

        public IMealsDateRepo MealsDateRepo { get; }

        public UnitOfWork( IMealsDateRepo _mealsDateRepo ,IUserRepo _userRepo , ICartRepo cartRepo ,ISubRepo subRepo, IPromotionRepo promotionRepo, ISectionRepo sectionRepo, IMealRepo mealRepo, IResturantRepo resturantRepo, IReviewRepo reviewRepo)
        {
            PromotionRepo = promotionRepo;
            SectionRepo = sectionRepo;
            CartRepo = cartRepo;
            MealRepo = mealRepo;
            ResturantRepo = resturantRepo;
            Subrepo = subRepo;
            MealsDateRepo = _mealsDateRepo;
            ReviewRepo = reviewRepo;
            UserRepo = _userRepo; 
        }

        public string SaveImageMethod(IFormFile? image)
        {
            var extension = Path.GetExtension(image!.FileName);
            var newName = $"{Guid.NewGuid()}{extension}";
            var newPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);

            using (var steam = new FileStream(newPath, FileMode.Create))
            {
                image!.CopyTo(steam);
            }

            return newName;

        }
    }
}
