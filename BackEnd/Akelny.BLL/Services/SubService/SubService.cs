using Akelny.BLL.Dto.SubDto;
using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.SubService;

public class SubService : ISubService
{

    private readonly IUnitOfWork _unitOfWork;

    public SubService( IUnitOfWork unitOfWork)
    {
       
        _unitOfWork = unitOfWork;
    }

    public void Add(AddSubDto sub, int userID)
    {
        var newSub = new Subscriptions
        {
            Substate = sub.SubState,
            Monthly_Price = sub.Monthly_price,
            TimeCreated = DateTime.Now,
            RenewDate = DateTime.Now.AddMonths(1),
            TestUserID = userID,
            Meals_Dates = sub.Meals_and_Dates!.Select(en => new Meals_Dates
            {
                MealID = en.Meal_id,
                Date = en.Arrival_Time

            }).ToList()
        };
        _unitOfWork.Subrepo.Add(newSub);
    }

    public void ChangeState( Subscriptions foundSUb , Substate state)
    {
        foundSUb.Substate = state;
        _unitOfWork.Subrepo.SaveChanges();
    }

    public void Delete(Subscriptions foundSUb)
    {
        _unitOfWork.Subrepo.Delete(foundSUb);
        _unitOfWork.Subrepo.SaveChanges();
    }

    public void AddMeals(SubsWithUser_Meals FoundSub, EditSubsDto subsDto)
    {
        var meals_added = subsDto.Meals_and_Dates!.Select(en => new Meals_Dates
        {
            MealID = en.Meal_id,
            Date = en.Arrival_Time,
            SubscriptionsID = FoundSub.Id,

        });

        var OldSub = _unitOfWork.Subrepo.GetSubByID(FoundSub.Id);

        OldSub.Meals_Dates = (OldSub.Meals_Dates!.Concat(meals_added)).ToList();
        
        _unitOfWork.Subrepo.SaveChanges();
    }

    public List<SubsWithUser_Meals> GetAll()
    {
        return _unitOfWork.Subrepo.GetAllSubs().Select(en => new SubsWithUser_Meals
        {
            Id = en.Id,
            Monthly_price = en.Monthly_Price,
            RenewDate = en.RenewDate,
            TimeCreated = en.TimeCreated,
            SubState = en.Substate,
            UserId = en.TestUserID,
            UserName = en.user!.Username,
            Meals_and_Dates = en.Meals_Dates!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                Meal_id = en.MealID
            }).ToList()
        }).ToList();
    }

    public List<SubsWithUser_Meals> GetAllByUserID(int userID)
    {
        return _unitOfWork.Subrepo.GetSubsByUserID(userID).Select(en => new SubsWithUser_Meals
        {
            Id= en.Id,
            Monthly_price=en.Monthly_Price,
            RenewDate=en.RenewDate,
            TimeCreated=en.TimeCreated,
            SubState=en.Substate,
            UserId=en.TestUserID,
            UserName=en.user!.Username,
            Meals_and_Dates = en.Meals_Dates!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                Meal_id = en.MealID
            }).ToList()
        }).ToList();
    }

  

    public SubsWithUser_FullMeals? GetSubByID(int subID)
    {
        var sub = _unitOfWork.Subrepo.GetSubByID(subID);

        return new SubsWithUser_FullMeals
        {
            Id = sub.Id,
            Monthly_price = sub.Monthly_Price,
            RenewDate = sub.RenewDate,
            TimeCreated = sub.TimeCreated,
            SubState = sub.Substate,
            UserId = sub.TestUserID,
            UserName = sub.user!.Username,
            FullMeals_and_Dates = sub.Meals_Dates!.Select(en => new FullMeals_and_Dates
            {
                Arrival_Time = en.Date,
                M_id = en.MealID,
                M_name = en.meal.Name,
                M_description = en.meal.Description,
                M_Price = en.meal.Price,
                Rest_ID = en.meal.RestaurantId

            }).ToList()

        };
    }


    public SubsWithUser_Meals? GetSubByIDWithMeals(int subID)
    {
        var sub = _unitOfWork.Subrepo.GetSubByID(subID);

        return new SubsWithUser_Meals
        {
            Id = sub.Id,
            Monthly_price = sub.Monthly_Price,
            RenewDate = sub.RenewDate,
            TimeCreated = sub.TimeCreated,
            SubState = sub.Substate,
            UserId = sub.TestUserID,
            UserName = sub.user!.Username,
            Meals_and_Dates = sub.Meals_Dates!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                Meal_id = en.MealID,
            

            }).ToList()

        };
    }

    public Subscriptions? GetSubWithoutIncludes(int id)
    {
        return _unitOfWork.Subrepo.GetById(id); 
    }

}
