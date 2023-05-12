using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.ResturantsDto;
using Akelny.BLL.Dto.SectionsDto;
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

        public void Add(SectionToAddDto sectionDto)
        {
            var section = new Section
            {
                Name= sectionDto.Name,

            };
            _unitOfWork.SectionRepo.Add(section);
            _unitOfWork.SectionRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            Section section = _unitOfWork.SectionRepo.GetById(id);
            if(section == null) { return; }
            if (section.Id != id)
                return ;
            _unitOfWork.SectionRepo.Delete(section);
            _unitOfWork.SectionRepo.SaveChanges();
        }

        public void Edit(int id, SectionToEditDto sectionDto)
        {
            Section section = _unitOfWork.SectionRepo.GetById(id);
            if (section == null) { return; }
            if (section.Id != id)
                return ;
            section.Name = sectionDto.Name;
            _unitOfWork.SectionRepo.Update(section);
            _unitOfWork.SectionRepo.SaveChanges();
        }

        public List<SectionDto> GetAll()
        {
            List<Section> sections = _unitOfWork.SectionRepo.GetAll();
            return sections.Select(s => new SectionDto
            {
                Id=s.Id,
                Name=s.Name
            }).ToList();
           
        }

        public SectionDto GetById(int id)
        {
            Section section = _unitOfWork.SectionRepo.GetById(id);

            if (section == null) { return null; }
            var sectionDto = new SectionDto();
            sectionDto.Id = section.Id;
            sectionDto.Name = section.Name;
          
            return sectionDto;

        }
    }
}
