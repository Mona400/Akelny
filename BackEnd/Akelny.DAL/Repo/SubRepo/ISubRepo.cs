using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.SubRepo;

public interface ISubRepo:IGenericRepo<Subscriptions>
{
    List<Subscriptions>? GetSubsWithUser_MealsByID(int subID);

    List<Subscriptions> GetSubsByUserID(int userID);

    List<Subscriptions> GetAllSubs();

    Subscriptions? GetSubByID(int Subid);
}
