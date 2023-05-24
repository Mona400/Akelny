using Akelny.DAL.Models;
using Akelny.DAL.Repo.GenericRepo;

namespace Akelny.DAL.Repo.CartRepo
{
    public interface ICartRepo : IGenericRepo<Cart>
    {
        public Cart? GetCartByUserId(int id);
        public Cart? GetCartById(int id);
        public void AddMealToCart(Meals_Dates meal, Cart cart);
        public void DeleteMealFromCart(Meals_Dates meal, Cart cart);


    }
}
