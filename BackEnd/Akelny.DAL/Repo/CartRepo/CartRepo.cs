using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace Akelny.DAL.Repo.CartRepo;

public class CartRepo : GenericRepo<Cart>, ICartRepo
{
    private readonly ApplicationDbContext _context;

    public CartRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }



    public void AddMealToCart(Meals_Dates meal, Cart cart)
    {
        cart.Meals?.Add(meal);
        SaveChanges();

    }
    public void DeleteMealFromCart(Meals_Dates meal, Cart cart)
    {
        cart.Meals?.Remove(meal);
        SaveChanges();

    }

    public List<Cart> GetAllCarts()
    {
        var carts = _context.Carts
            .Include(m => m.Meals)
           .ToList();
        return carts;
    }

    public Cart? GetCartById(int id)
    {
        var CartId = _context.Carts.Where(c => c.Id == id)
             .Include(c => c.Meals)
             .Include(c => c.PaymentDetails)
             .SingleOrDefault(c => c.Id == id);
        return CartId;
    }

    public Cart? GetCartByUserId(string id)
    {
        var CartId = _context.Carts.Where(c => c.UserId == id)
             .Include(c => c.PaymentDetails)
              .Include(c => c.Meals)!
             .ThenInclude(c => c.Restaurant)
             .SingleOrDefault();
        return CartId;
    }


}
