

using System.ComponentModel.DataAnnotations.Schema;

namespace Akelny.DAL.Models;

public class Meals_Dates
{
    public int ID { get; set; }

    [Column("Sub_ID")]
    public int? SubscriptionsID { get; set; }

    public Subscriptions? Subscriptions { get; set; }

 
    public string Date { get; set; } = string.Empty;

    [Column("Meal_ID")]
    public int MealID { get; set; }
    public decimal MealPrice { get; set; }
    public string MealTitle { get; set; } = string.Empty;
    public int? RestaurantID { get; set; }
    public Restaurant? Restaurant { get; set; }
    public string RestTitle { get; set; } = string.Empty;
    public string RestImg { get; set; } = string.Empty;

    public string MealImage { get; set; } = string.Empty;
    public Meal? Meal { get; set; }
    public Cart? Cart { get; set; }
}
