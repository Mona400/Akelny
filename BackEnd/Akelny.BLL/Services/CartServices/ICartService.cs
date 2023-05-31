using Akelny.BLL.Dto.CartDto;
using Akelny.BLL.Dto.ReviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.CartServices;

public interface ICartService
{
    List<CartDto> GetAll();
    void Add(CartToAddDto cartDto);
    int? Edit(int id, CartToEditDto cartToEditdto);
    int? Delete(int id);
    public CartDto? GetById(int id);
}
