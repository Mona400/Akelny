using Akelny.BLL.Dto.SubDto;
using Akelny.BLL.Services.MealServices;
using Akelny.BLL.Services.SubService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {
        private readonly ISubService _subService;

        private readonly IMealServices _mealService;
        public SubController(ISubService subService, IMealServices mealServices)
        {
            _subService = subService;
            _mealService = mealServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var subs = _subService.GetAll();

            if (subs.IsNullOrEmpty())
            {
                return BadRequest("Not Subscriptions exists");
            }
            return Ok(subs);
        }

        [HttpGet]
        [Route("users/{userID}/sub")]
        public IActionResult GetAllByID(string userID)
        {
            var subs = _subService.GetAllByUserID(userID);

            if (subs.IsNullOrEmpty())
            {
                return BadRequest("Not Subscriptions with that userID");
            }
            return Ok(subs);
        }

        [HttpPatch]
        [Route("{SubID}")]
        public IActionResult GetAllByID(SubStateDto state, int SubID)
        {

            var foundSub = _subService.GetSubWithoutIncludes(SubID);

            if (foundSub is null) { return BadRequest("No Such Record Was Found"); }

            _subService.ChangeState(foundSub, state.substate);
            return Ok("status was changed successfully");
        }

        [HttpGet]
        [Route("{SubID}")]
        public IActionResult GetByID(int SubID)
        {
            var foundSub = _subService.GetSubByID(SubID);

            if (foundSub is null) { return BadRequest("No Such Record Was Found"); }

            return Ok(foundSub);
        }

        [HttpPost]
        [Route("users/{userID}/sub")]
        public IActionResult Create(AddSubDto SubDto, string userID)
        {
            //insert the getUserByID here

            try
            {
                _subService.Add(SubDto, userID);
            }
            catch (Exception)
            {

                return BadRequest("bad UserID or MealID ");
            }


            return CreatedAtAction(
                actionName: nameof(GetAll),
                value: "Added Successfully"
                );
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var foundSub = _subService.GetSubWithoutIncludes(id);

            if (foundSub is null) { return BadRequest("No Such Record Was Found"); }

            _subService.Delete(foundSub);

            return Ok("record was deleted successfully");

        }

        //[HttpPatch]
        //[Route("users/{userID}/sub/{subID}")]
        //public IActionResult Update(int subID, EditSubsDto SubDto)
        //{
        //    var foundSub = _subService.GetSubByID(subID);

        //    if (foundSub is null) { return BadRequest("No Such Record Was Found"); }

        //    _subService.Delete(foundSub);

        //    return Ok("record was deleted successfully");

        //}

        [HttpPatch]
        [Route("{subID}/meals")]
        public IActionResult AddingMeals(int subID, EditSubsDto SubDto)


        {
            var foundSub = _subService.GetSubByIDWithMeals(subID);

            if (foundSub is null) { return BadRequest("No Such Record Was Found"); }

            _subService.AddMeals(foundSub, SubDto);

            return Ok("Meals were added successfully");

        }
    }
}
