using Akelny.BLL.Dto.PromotionDto;
using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.PromotionServices
{
    public interface IPromotionServices
    {
        List<PromotionDto> GetAll();
        void Add(PromotionToAddDto promotionToAddDto);
        void Edit(int id, PromotionToEditDto promotionToEditDto);
        void Delete(int id);
        Promotion? GetById(int id);

    }
}
