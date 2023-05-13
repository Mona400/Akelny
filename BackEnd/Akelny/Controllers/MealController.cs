using Akelny.BLL.Dto.MealDto;
using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.SectionsDto;
using Akelny.BLL.Services.MealServices;
using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealServices _mealServices;
        private readonly ApplicationDbContext _context;
        public MealController(IMealServices mealServices, ApplicationDbContext context)
        {
            _mealServices = mealServices;
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<MealDto>> GetAll()
        {
            return _mealServices.GetAll();
        }
        [HttpPost]
        public ActionResult Add([FromForm] MealToAddDto mealToAddDto)
        {
           _mealServices.AddMeal(mealToAddDto);
            
            return CreatedAtAction(
              actionName: nameof(GetAll),
              value: "Added Successfully");
        }

        [HttpGet("GetAllByResturantId")]
        public ActionResult<List<MealResturantDto>> GetAllByResturantId(int? id)
        {
            return _mealServices.GetAllByResturantId(id);
        }
        [HttpGet("GetAllBySectiontId")]
        public ActionResult<List<MealSectionDto>> GetAllBySectionId(int? id)
        {
            return _mealServices.GetAllBySectionId(id);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(int id,[FromForm] MealToEditDto mealToEditDto)
        {
            if (mealToEditDto.Id != id) return NotFound(new { Message = "No Resturant Found!!" });
            _mealServices.Edit(id, mealToEditDto);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Updated Successfully");

        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<MealDto> Delete(int id, MealDto mealDto)
        {
            if (mealDto.Id != id) return NotFound(new { Message = "No Resturant Found!!" });
            _mealServices.Delete(id);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Deleted Successfully");

        }
        [HttpGet]
        [Route("GetBy{id}")]
        public ActionResult<MealDto> GetById(int id)
        {
            return _mealServices.GetById(id);
        }


    }
}
