using Akelny.DAL.Repo.PromotionRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IPromotionRepo PromotionRepo { get; }
    }
}
