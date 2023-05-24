using Akelny.DAL.Repo.MealRepo;
using Akelny.DAL.Repo.PromotionRepo;
using Akelny.DAL.Repo.ResturantRepo;
using Akelny.DAL.Repo.ReviewRepo;
using Akelny.DAL.Repo.SectionRepo;
using Akelny.DAL.Repo.SubRepo;
using Microsoft.AspNetCore.Http;

namespace Akelny.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPromotionRepo PromotionRepo { get; }
        public ISectionRepo SectionRepo { get; }
        public IMealRepo MealRepo { get; }
        public IResturantRepo ResturantRepo { get; }

        public ISubRepo Subrepo { get; }
        public IReviewRepo ReviewRepo { get; }
        public string SaveImageMethod(IFormFile? image);
    }
}
