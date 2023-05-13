using Akelny.BLL.Dto.SubDto;
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
    

    List<SubsWithUser_Meals> GetAllByUserID(int userID);

    List<SubsWithUser_Meals> GetAll();

    SubsWithUser_FullMeals? GetSubByID(int subID);

    SubsWithUser_Meals? GetSubByIDWithMeals(int subID);

    void Delete(Subscriptions foundSUb);
    void Add(AddSubDto sub , int userID);

    Subscriptions? GetSubWithoutIncludes(int id);

    void AddMeals(SubsWithUser_Meals FoundSub, EditSubsDto subsDto);
}
