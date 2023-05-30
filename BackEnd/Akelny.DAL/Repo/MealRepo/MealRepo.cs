using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
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


        public List<Meal> GetAllByResturantId(int? ResturantId)
        {
            var meals =  _context.Meals
             .Include(m=>m.Restaurant)
             .Include(m=>m.Section)
             .Where(p => p.Restaurant!.Id == ResturantId)
            .ToList();
            return meals;
        }

        public List<Meal> GetAllBySectionId(int? SectionId)
        {
            var meals = _context.Meals
             .Include(m => m.Section)
             .Where(m => m.Section!.Id == SectionId)
            .ToList();
            return meals;
        }

        public Meal? GetMealById(int? MealId)
        {
            var meal = _context.Meals
             .Include(m => m.Section)
             .Include(m => m.Restaurant)
             .Where(r => r.Id == MealId).FirstOrDefault(r => r.Id == MealId);

            return meal;
        }
    }
}
