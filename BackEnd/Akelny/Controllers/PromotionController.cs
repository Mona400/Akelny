using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Services.PromotionServices;
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
        public ActionResult Add(PromotionDto promotionDto)
        {
            _promotionServices.Add(promotionDto);
            return CreatedAtAction(
                actionName: nameof(GetAll),
                value: promotionDto);
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id, PromotionDto promotionDto)
        {
            if (promotionDto.Id != id) return NotFound(new { Message = "No promotion Found!!" });

            _promotionServices.Edit(id, promotionDto);
            return CreatedAtAction(
                actionName: nameof(GetAll),
                value: "Updated Successfully");
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id, PromotionDto promotionDto)
        {
            if (promotionDto.Id != id) return NotFound(new { Message = "No promotion Found!!" });

            _promotionServices.Delete(id);
            return CreatedAtAction(
                actionName: nameof(GetAll),
                value: "Deleted Successfully");

        }
    }
}
