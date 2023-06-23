using Akelny.BLL.Dto.CartDto;
using Akelny.BLL.Dto.ReviewDto;
using Akelny.BLL.Dto.SubDto;
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
    public OneCardDto? GetById(string userId);

    public List<MealsAndDatesDto>? GetAllMealByCartID(int cartID);

    public OneCardDto? AddMealsToCart(string userID, MealsAndDatesDto mdto);

    public OneCardDto? RemoveMealsFromCart(string userID, int mealID);
}
