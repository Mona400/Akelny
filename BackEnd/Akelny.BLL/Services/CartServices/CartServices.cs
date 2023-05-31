using Akelny.BLL.Dto.CartDto;
using Akelny.BLL.Dto.MealDto;
using Akelny.BLL.Dto.SubDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;

namespace Akelny.BLL.Services.CartServices;

public class CartServices : ICartService
{
    private readonly IUnitOfWork _unitOfWork;
    public CartServices(IUnitOfWork unitofwork)
    {
        _unitOfWork = unitofwork;
    }
    public void Add(CartToAddDto cartDto)
    {
        _unitOfWork.CartRepo.Add(new DAL.Models.Cart
        {
            Discount = cartDto.Discount,
            MonthlyPrice = cartDto.MonthlyPrice,
            PaymentDetails = cartDto.PaymentDetails,
            Meals = cartDto.Meals_dates!.Select(me => new Meals_Dates { MealID = me.Meal_id, Date = me.Arrival_Time }).ToList(),
            UserId = cartDto.UserId
        });

        _unitOfWork.CartRepo.SaveChanges();
    }

    public int? Delete(int id)
    {
        Cart? cart = _unitOfWork.CartRepo.GetCartById(id);

        if (cart == null) { return null; }

        _unitOfWork.CartRepo.Delete(cart);
        _unitOfWork.CartRepo.SaveChanges();
        return id;
    }

    public int? Edit(int id, CartToEditDto cartToEditdto)
    {
        Cart? cart = _unitOfWork.CartRepo.GetById(id);

        if (cart == null) { return null; }

        //what if all data is empty
        cart.MonthlyPrice = cartToEditdto.MonthlyPrice;
        cart.Meals = cartToEditdto.Meals_dates!.Select(en => new Meals_Dates { MealID=en.Meal_id
        , Date = en.Arrival_Time
        }).ToList();
       

        _unitOfWork.CartRepo.Update(cart);
        _unitOfWork.CartRepo.SaveChanges();
        return id;
    }


    public List<CartDto> GetAll()
    {
        var carts = _unitOfWork.CartRepo.GetAll();

        return carts.Select(m => new CartDto
        {
            Id = m.Id,
            Meals = m.Meals!.Select(me => new MealsAndDatesDto { Meal_id=me.MealID , Arrival_Time = me.Date}).ToList(),
            Discount = m.Discount,
            MonthlyPrice = m.MonthlyPrice,
            PaymentDetails = m.PaymentDetails,
            UserId = m.UserId


        }).ToList();
    }

    public CartDto? GetById(int id)
    {
        Cart? cart = _unitOfWork.CartRepo.GetCartById(id);

        if (cart == null) { return null; }
        var CartDto = new CartDto();

        CartDto.Id = cart.Id;
        CartDto.Meals = cart.Meals!.Select(me => new MealsAndDatesDto { Meal_id = me.MealID, Arrival_Time = me.Date }).ToList();
        CartDto.Discount = cart.Discount;
        CartDto.MonthlyPrice = cart.MonthlyPrice;
        CartDto.PaymentDetails = cart.PaymentDetails;
        CartDto.UserId = cart.UserId;
        return CartDto;
    }



}
