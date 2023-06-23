using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.ResturantRepo
{
    public class ResturantRepo:GenericRepo<Restaurant>, IResturantRepo
    {
        private readonly ApplicationDbContext _context;
        public ResturantRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public Restaurant? GetResturantById(int? ResturantId)
        {
            var restaurant = _context.Restaurant
              .Where(r => r.Id == ResturantId)
             .Include(m => m.Sections)
             .Include(m => m.Meals)
             .Include(m => m.Reviews)
             .FirstOrDefault();
           
            return restaurant;
        }
    }
}
