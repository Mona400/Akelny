using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.SubRepo;

public class SubRepo : GenericRepo<Subscriptions>, ISubRepo
{
    private readonly ApplicationDbContext _context;
    public SubRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public List<Subscriptions> GetAllSubs()
    {
       return _context.Subscriptions.Include(en => en.user).Include(en => en.Meals_Dates).ToList();
    }

    public Subscriptions? GetSubByID(int Subid)
    {
        return _context.Subscriptions.Where(re => re.Id == Subid).Include(en => en.user).Include(en => en.Meals_Dates)!.ThenInclude(en => en.Meal).SingleOrDefault();
    }

    public List<Subscriptions> GetSubsByUserID(string userID)
    {
        return _context.Subscriptions.Where(en => en.TestUserID == userID).Include(en => en.user).Include(en => en.Meals_Dates).ToList();
    }



    public List<Subscriptions>? GetSubsWithUser_MealsByID(int subID)
    {
        return _context.Subscriptions.Where(en => en.Id == subID).Include(en => en.Meals_Dates).ToList();
    }
}
