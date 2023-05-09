using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Akelny.DAL.Repo.PromotionRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.SectionRepo
{
   public class SectionRepo : GenericRepo<Section>, ISectionRepo
    {
        private readonly ApplicationDbContext _context;

        public SectionRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}