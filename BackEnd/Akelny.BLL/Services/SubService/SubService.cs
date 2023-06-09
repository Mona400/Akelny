﻿using Akelny.BLL.Dto.SubDto;
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

    public void Add(AddSubDto sub, string userID)
    {
        var newSub = new Subscriptions
        {
            Substate = sub.SubState,
            Monthly_Price = sub.Monthly_price,
            TimeCreated = DateTime.Now,
            RestaurantID = sub.RestaurantID,
            RestaurantImg = sub.RestaurantImg,
            PaymentDetails = sub.PaymentDetails,
            RenewDate = DateTime.Now.AddMonths(1),
            TestUserID = userID,
            Meals_Dates = sub.Meals_and_Dates!.Select(en => new Meals_Dates
            {
                MealID = en.Meal_id,
                MealImage = en.Meal_Img,
                MealTitle = en.Meal_Name,
                ID = en.ID,
                RestaurantID = en.RestID,
                RestImg = en.RestImg,
                RestTitle = en.RestTitle,
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

    public void AddMeals(SubsWithUser_Meals FoundSub, EditSubsDto subsDto , Subscriptions OldSub)
    {
        

        var meals_added = subsDto.Meals_and_Dates!.Select(en => new Meals_Dates
        {
            MealID = en.Meal_id,
            MealImage = en.Meal_Img,
            Date = en.Arrival_Time,
            ID = en.ID,
            RestaurantID = en.RestID,
            RestTitle = en.RestTitle,
            RestImg= en.RestImg,
            MealPrice = en.Meal_Price,
            MealTitle = en.Meal_Name,
   
            SubscriptionsID = FoundSub.Id,

        });

       

        OldSub.Meals_Dates = meals_added.ToList();
        
       // _unitOfWork.Subrepo.SaveChanges();
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
            UserId = en.TestUserID!,
            UserName = en.user!.UserName!,
            Meals_and_Dates = en.Meals_Dates!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                Meal_Name = en.MealTitle,
                Meal_Img = en.MealImage,
                Meal_id = en.MealID
            }).ToList()
        }).ToList();
    }

    public List<SubsWithUser_Meals> GetAllByUserID(string userID)
    {
        return _unitOfWork.Subrepo.GetSubsByUserID(userID).Select(ener => new SubsWithUser_Meals
        {
            Id= ener.Id,
            Monthly_price= ener.Monthly_Price,
            RenewDate= ener.RenewDate,
            TimeCreated= ener.TimeCreated,
            RestaurantID = ener.RestaurantID ?? 0,
            RestaurantImg = ener.RestaurantImg,
            SubState= ener.Substate,
            UserId= ener.TestUserID!,
            UserName= ener.user!.UserName!,
            Meals_and_Dates = ener.Meals_Dates!.Select(en => new MealsAndDatesDto
            {
                Arrival_Time = en.Date,
                ID= en.ID,  
                RestID = ener.RestaurantID ?? 0,
                RestImg = en.RestImg,
                RestTitle= en.RestTitle,
                Meal_Img = en.MealImage,
                Meal_Name = en.MealTitle,
                Meal_id = en.MealID
            }).ToList()
        }).ToList();
    }

  

    public SubsWithUser_FullMeals? GetSubByID(int subID)
    {
        var sub = _unitOfWork.Subrepo.GetSubByID(subID);

        if(sub is null) { return null; }

        return new SubsWithUser_FullMeals
        {
            Id = sub.Id,
            Monthly_price = sub.Monthly_Price,
            RenewDate = sub.RenewDate,
            TimeCreated = sub.TimeCreated,
            SubState = sub.Substate,
            UserId = sub.TestUserID!,
            UserName = sub.user!.UserName!,
            FullMeals_and_Dates = sub.Meals_Dates!.Select(en => new FullMeals_and_Dates
            {
                Arrival_Time = en.Date,
                M_id = en.MealID,
                M_name = en.Meal!.Name,
                M_description = en.Meal.Description,
                M_Image = en.MealImage,
                M_Price = en.Meal.Price,
                Rest_ID = en.Meal.RestaurantId

            }).ToList()

        };
    }


    public int? GetSubByIDWithMeals(int subID , EditSubsDto subsDto)
    {
        _unitOfWork.Subrepo.SaveChanges();
        var sub = _unitOfWork.Subrepo.GetSubByID(subID);

        if(sub is null) { return null; }

        var oldmeals = sub.Meals_Dates;

       
      
        //var suber = new SubsWithUser_Meals
        //{
        //    Id = sub.Id,
        //    Monthly_price = sub.Monthly_Price,
        //    RenewDate = sub.RenewDate,
        //    TimeCreated = sub.TimeCreated,
        //    RestaurantID = (int)sub.RestaurantID!,
        //    RestaurantImg = sub.RestaurantImg,
        //    SubState = sub.Substate,
        //    UserId = sub.TestUserID!,
        //    UserName = sub.user!.UserName!,
        //    Meals_and_Dates = sub.Meals_Dates!.Select(en => new MealsAndDatesDto
        //    {
        //        Arrival_Time = en.Date,
        //        Meal_id = en.MealID,
        //        ID = en.ID,
        //        Meal_Price = en.MealPrice,
        //        RestImg = en.RestImg,
        //        RestTitle = en.RestTitle,
        //        RestID = en.RestaurantID ?? 0,
        //        Meal_Name = en.MealTitle,
        //        Meal_Img = en.MealImage

        //    }).ToList()

        //};






        var meals_added = subsDto.Meals_and_Dates!.Select(en => new Meals_Dates
        {
            MealTitle= en.Meal_Name,
            RestaurantID = en.RestID,
            MealID = en.Meal_id,
            MealImage = en.Meal_Img,
        
            MealPrice = en.Meal_Price,
            Date = en.Arrival_Time,
            RestImg= en.RestImg,
            SubscriptionsID= subID,
            RestTitle= en.RestTitle
            
            
                

        }).ToList();

        sub.Meals_Dates = meals_added;
        _unitOfWork.Subrepo.SaveChanges();
    

        return 1;
    }

    public Subscriptions? GetSubWithoutIncludes(int id)
    {
        return _unitOfWork.Subrepo.GetById(id); 
    }

}
