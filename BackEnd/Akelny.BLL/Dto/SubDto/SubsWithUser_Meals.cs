

using Akelny.DAL.Models;
using Microsoft.VisualBasic;

namespace Akelny.BLL.Dto.SubDto;


public class MealsAndDatesDto
{

    public int ID { get; set; }
    public int Meal_id { get; set; }

    public string Meal_Img { get; set; } = string.Empty;
    public string RestImg { get; set; } = string.Empty;
    public string RestTitle { get; set; } = string.Empty;
    public decimal Meal_Price { get; set; }
    public int RestID { get; set; }
    public string Meal_Name { get; set; } = string.Empty;
    public string Arrival_Time { get; set; } = string.Empty;

}

public class FullMeals_and_Dates
{


    public int M_id { get; set; }

    public string M_name { get; set; } = string.Empty;
    public decimal? M_Price { get; set; } = decimal.Zero;
    public string? M_Image { get; set; }=string.Empty;
    public string M_description { get; set; } = string.Empty;

    public int Rest_ID { get; set; }
    public string Arrival_Time { get; set; } = string.Empty;

}
public class SubsWithUser_Meals
{


    public int Id { get; set; }
    public int RestaurantID { get; set; }
    public string RestaurantImg { get; set; }=string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public decimal Monthly_price { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime RenewDate { get; set; }

    public Substate SubState { get; set; }

    public ICollection<MealsAndDatesDto>? Meals_and_Dates { get; set; }
}

public class SubStateDto
{
    public Substate substate { get; set; }
}
public class SubsWithUser_FullMeals
{


    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public decimal Monthly_price { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime RenewDate { get; set; }

    public Substate SubState { get; set; }

    public ICollection<FullMeals_and_Dates>? FullMeals_and_Dates { get; set; }

}

public class EditSubsDto
{



    public List<MealsAndDatesDto>? Meals_and_Dates { get; set; }

}


public class AddSubDto
{



    //public int UserId { get; set; }


    public decimal Monthly_price { get; set; }
    //public DateTime TimeCreated { get; set; }
    //public DateTime ExpirationDate { get; set; }
    public int RestaurantID { get; set; }

    public string RestaurantImg { get; set; } = string.Empty;
    public Substate SubState { get; set; }
    public PaymentDetails? PaymentDetails { get; set; }
    public ICollection<MealsAndDatesDto>? Meals_and_Dates { get; set; }

}
