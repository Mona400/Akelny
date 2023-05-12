using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.SectionsDto;
using Akelny.BLL.Services.SectionServices;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionServices _sectionServices;

        public SectionController(ISectionServices sectionServices)
        {
            _sectionServices = sectionServices;
        }
        [HttpGet]
        public ActionResult<List<SectionDto>> GetAll()
        {
            return _sectionServices.GetAll();
        }
        [HttpPost]
        public ActionResult Add(SectionToAddDto sectionToAddDto)
        {
            _sectionServices.Add(sectionToAddDto);
            return CreatedAtAction(
              actionName: nameof(GetAll),
              value: "Added Successfully");
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, SectionToEditDto sectionToEditDto)
        {
            if (sectionToEditDto.Id != id) return NotFound(new { Message = "No Section Found!!" });

            _sectionServices.Edit(id, sectionToEditDto);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Updated Successfully");

        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<SectionDto> Delete(int id, SectionDto sectionDto)
        {
            if (sectionDto.Id != id) return NotFound(new { Message = "No Section Found!!" });

            _sectionServices.Delete(id);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Deleted Successfully");

        }
        [HttpGet]
        [Route("GetBy{id}")]
        public ActionResult<SectionDto> GetById(int id)
        {
            return _sectionServices.GetById(id);
        }
    }
}
