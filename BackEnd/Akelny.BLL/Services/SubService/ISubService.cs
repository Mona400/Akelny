﻿using Akelny.BLL.Dto.SubDto;
using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.SubService;

public interface ISubService
{
    void ChangeState(Subscriptions foundSUb, Substate state);
    

    List<SubsWithUser_Meals> GetAllByUserID(string userID);

    List<SubsWithUser_Meals> GetAll();

    SubsWithUser_FullMeals? GetSubByID(int subID);

    int? GetSubByIDWithMeals(int subID , EditSubsDto subsDto);

    void Delete(Subscriptions foundSUb);
    void Add(AddSubDto sub , string userID);

    Subscriptions? GetSubWithoutIncludes(int id);

    void AddMeals(SubsWithUser_Meals FoundSub, EditSubsDto subsDto , Subscriptions OldSub);
}
