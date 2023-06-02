using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Services.PromotionServices;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionServices _promotionServices;

        public PromotionController(IPromotionServices promotionServices)
        {
            _promotionServices = promotionServices;
        }
        [HttpGet]
        public ActionResult<List<PromotionDto>> GetAll()
        {
            return _promotionServices.GetAll();
        }
        [HttpPost]
        public ActionResult Add([FromForm] PromotionToAddDto promotionDto)
        {
            _promotionServices.Add(promotionDto);
            return CreatedAtAction(
              actionName: nameof(GetAll),
              value: "Added Successfully");
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, [FromForm] PromotionToEditDto promotionDto)
        {
            if (promotionDto.Id != id) return NotFound(new { Message = "No Department Found!!" });

            _promotionServices.Edit(id, promotionDto);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Updated Successfully");

        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<PromotionDto> Delete(int id)
        {
            if (_promotionServices.GetById(id) == null ) return NotFound(new { Message = "No Department Found!!" });

            _promotionServices.Delete(id);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Deleted Successfully");

        }
        [HttpGet]
        [Route("GetBy{id}")]
        public ActionResult <Promotion?> GetById(int id)
        {
            return _promotionServices.GetById(id);
        }
    }
}
