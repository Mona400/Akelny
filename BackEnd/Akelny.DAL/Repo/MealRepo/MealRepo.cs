using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.MealRepo
{
    public class MealRepo:GenericRepo<Meal>,IMealRepo
    {
        private readonly ApplicationDbContext _context;

        public MealRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
