using Akelny.DAL.Models;
using Akelny.DAL.Repo.MealRepo;
using Akelny.DAL.Repo.PromotionRepo;
using Akelny.DAL.Repo.ResturantRepo;
using Akelny.DAL.Repo.SectionRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPromotionRepo PromotionRepo { get; }
        public ISectionRepo SectionRepo { get; }
        public IMealRepo MealRepo { get; }
        public IResturantRepo ResturantRepo { get; }
        public UnitOfWork(IPromotionRepo promotionRepo, ISectionRepo sectionRepo, IMealRepo mealRepo, IResturantRepo resturantRepo)
        {
            PromotionRepo = promotionRepo;
            SectionRepo = sectionRepo;
            MealRepo = mealRepo;
            ResturantRepo = resturantRepo;
        }
    }
}
