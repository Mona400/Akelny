

using System.ComponentModel.DataAnnotations.Schema;

namespace Akelny.DAL.Models;

public class Meals_Dates
{
    public int ID { get; set; }

    [Column("Sub_ID")]
    public int SubscriptionsID { get; set; }

    public Subscriptions Subscriptions { get; set; }
    public string Date { get; set; }

    [Column("Meal_ID")]
    public int MealID { get; set; }
    public Meal meal { get; set; }
    public Cart? Cart { get; set; }
}
