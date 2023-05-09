using Akelny.DAL.Repo.PromotionRepo;
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
      

        public UnitOfWork(IPromotionRepo promotionRepo, ISectionRepo sectionRepo)
        {
            PromotionRepo = promotionRepo;
            SectionRepo = sectionRepo;
           
        }
    }
}
