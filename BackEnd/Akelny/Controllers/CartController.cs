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

            return Ok(cart);

        }

        [HttpGet]
        public IActionResult Index()
        {
            var cart = _cartService.GetAll();

            return Ok(cart);

        }
    }
}
