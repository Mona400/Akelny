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
        List<Section> GetAll();
        Section Add(SectionDto sectionDto);
        Section Edit(int id, SectionDto sectionDto);

        Section Delete(int id);
    }
}
