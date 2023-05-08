using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.PromotionRepo
{
    public class PromotionRepo : GenericRepo<Promotion>, IPromotionRepo
    {
        private readonly ApplicationDbContext _context;
      
        public PromotionRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
