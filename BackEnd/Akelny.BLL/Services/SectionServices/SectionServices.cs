using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.SectionDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.SectionServices
{
    public class SectionServices : ISectionServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Section Add(SectionDto sectionDto)
        {
            var Section = new Section
            {
                Name=sectionDto.Name,
            };

            _unitOfWork.SectionRepo.Add(Section);
            _unitOfWork.SectionRepo.SaveChanges();

            return Section;
        }

        public Section Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Section Edit(int id, SectionDto sectionDto)
        {
            throw new NotImplementedException();
        }

        public List<Section> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
