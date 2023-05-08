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
        Promotion Add(PromotionDto department);
        void Edit(int id, PromotionDto departmentDpo);

        void Delete(int id);
    }
}
