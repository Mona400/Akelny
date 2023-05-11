using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.SectionDto;
using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.SectionServices
{
    public interface ISectionServices
    {
        List<SectionDto> GetAll();
       void Add(SectionToAddDto sectionDto);
       void Edit(int id, SectionToEditDto sectionDto);
       void Delete(int id);
      Section GetById(int id);
    }
}
