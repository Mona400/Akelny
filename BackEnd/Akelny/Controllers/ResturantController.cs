using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.ResturantsDto;
using Akelny.BLL.Services.ResturantServices;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.ResturantRepo;
using Akelny.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : ControllerBase
    {
        
        private readonly IResturantServices _resturantServices;

        public ResturantController(IResturantServices resturantServices)
        {
            _resturantServices = resturantServices;
        }

        [HttpGet]

        public ActionResult<List<ResturantDto>> GetAll()
        {
            return _resturantServices.GetAll();
        }
        [HttpPost]
        [HttpPost]
        public ActionResult Add(ResturantToAddDto resturantToAddDto)
        {
            _resturantServices.Add(resturantToAddDto);
            return CreatedAtAction(
              actionName: nameof(GetAll),
              value: "Added Successfully");
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, ResturantToEditDto resturantToEditDto)
        {
            if (resturantToEditDto.Id != id) return NotFound(new { Message = "No Resturant Found!!" });
            _resturantServices.Edit(id, resturantToEditDto);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Updated Successfully");

        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<PromotionDto> Delete(int id, ResturantDto resturantDto)
        {
            if (resturantDto.Id != id) return NotFound(new { Message = "No Resturant Found!!" });
            _resturantServices.Delete(id);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Deleted Successfully");

        }
        [HttpGet]
        [Route("GetBy{id}")]
        public ActionResult<ResturantDto> GetById(int id)
        {
            return _resturantServices.GetById(id);
        }
    }
}
