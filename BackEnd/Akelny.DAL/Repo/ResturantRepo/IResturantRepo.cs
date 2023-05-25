using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.ResturantRepo
{
    public interface IResturantRepo:IGenericRepo<Restaurant>
    {
        Restaurant? GetResturantById(int? ResturantId);
    }
}
