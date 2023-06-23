using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Akelny.DAL.Repo.MealRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.Meals_Dates_Repo
{
    public class MealsDateRepo : GenericRepo<Meals_Dates>, IMealsDateRepo
    {
        private readonly ApplicationDbContext _context;

        public MealsDateRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
