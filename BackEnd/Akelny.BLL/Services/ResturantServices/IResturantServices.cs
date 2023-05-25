using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.ResturantsDto;
using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.ResturantServices
{
    public interface IResturantServices
    {
        List<ResturantDto> GetAll();
        void Add(ResturantToAddDto resturantToAddDto);
        void Edit(int id, ResturantToEditDto resturantToEditDto);
        void Delete(int id);
        //Restaurant GetById(int id);
         ResturantDto? GetById(int id);

    }
}
