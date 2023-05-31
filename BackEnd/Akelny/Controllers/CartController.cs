using Akelny.BLL.Dto.CartDto;
using Akelny.BLL.Services.CartServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] CartToAddDto cartToAddDto)
        {
            _cartService.Add(cartToAddDto);

            return Ok("Added Successfully");

        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id , [FromBody] CartToEditDto cartToEditDto)
        {
            _cartService.Edit(id, cartToEditDto);

            return Ok("Updated Successfully");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cartService.Delete(id);

            return Ok("Deleted Successfully");

        }

        [HttpGet("{id}")]
        public IActionResult GryByID(int id)
        {
            var cart = _cartService.GetById(id);
            if(cart== null) { return NotFound("Cart Doesn't Exists"); }
            return Ok( new CartDto
            {
                Discount = cart.Discount,
                Id= cart.Id,
                Meals= cart.Meals,
                MonthlyPrice= cart.MonthlyPrice,
                PaymentDetails= cart.PaymentDetails,
                UserId = cart.UserId
            });

        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartService.GetAll();

            return Ok(cart);

        }
    }
}
