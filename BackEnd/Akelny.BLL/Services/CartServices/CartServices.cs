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

    public OneCardDto AddMealsToCart(int cartID, List<MealsAndDatesDto> mdto)
    {
        var cart = _unitOfWork.CartRepo.GetCartById(cartID);

        if(cart is null) { return null; }

        cart.Meals = mdto.Select(en => new Meals_Dates { Date = en.Arrival_Time, MealID = en.Meal_id }).ToList();

        _unitOfWork.CartRepo.SaveChanges();

        return new OneCardDto
        {
            Discount = cart.Discount,
            MonthlyPrice = cart.MonthlyPrice,
            Id = cart.Id,
            Meals = cart.Meals!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                Meal_id = en.MealID

            }).ToList(),
            PaymentDetails = cart.PaymentDetails,
            UserId = cart.UserId,

        };
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
        var carts = _unitOfWork.CartRepo.GetAllCarts();

        return carts.Select(m => new CartDto
        {
            Id = m.Id,
            Meals = m.Meals!.Select(en => new MealsAndDatesDto
            {
                Meal_id = en.MealID,
                Arrival_Time = en.Date
            }).ToList(),
            Discount = m.Discount,
            MonthlyPrice = m.MonthlyPrice,
        
            UserId = m.UserId


        }).ToList();
    }

    public List<MealsAndDatesDto>? GetAllMealByCartID (int cartID)
    {
       var cart = _unitOfWork.CartRepo.GetCartById(cartID);
        if(cart is null) { return null; }

        return cart.Meals!.Select(en => new MealsAndDatesDto
        {
            Arrival_Time = en.Date,
            Meal_id = en.MealID
        }).ToList()  ;
    }

    public OneCardDto? GetById(int id)
    {
        Cart? cart = _unitOfWork.CartRepo.GetCartById(id);

        if (cart == null) { return null; }
        var CartDto = new OneCardDto
        {
            Discount = cart.Discount,
            MonthlyPrice = cart.MonthlyPrice,
            Id = cart.Id,
            Meals = cart.Meals!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                Meal_id = en.MealID

            }).ToList(),
            PaymentDetails = cart.PaymentDetails,
            UserId = cart.UserId,

        };
        
    
        return CartDto;
    }



}
