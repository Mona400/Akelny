using Akelny.BLL.Dto.ReviewDto;
using Akelny.BLL.Dto.SubDto;
using Akelny.BLL.Dto.UserDto;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  ReturnedUserDTO? GetUserDTO(string id)
        {
            var user =  _unitOfWork.UserRepo.GetUser(id);

            if (user == null) { return null; }

            return new ReturnedUserDTO
            {
                Address = user.Address,
                DOB = user.DOB,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                UserName = user.UserName!,
                IsEmailVerified = user.IsEmailVerified,
                ProfileImg = user.ProfileImg,
                Gender = user.Gender,
                UserType = user.UserType,
                Reviews = user.Reviews?.Select(re => new MinReviewDTO { Comment = re.Comment, ID = re.Id, Impression = re.Impression, TimeCreated = re.TimeCreated }).ToList(),
                Subscriptions = user.subscriptions?.Select(re => new MinSubDTO
                {
                    ID = re.Id,
                    Monthly_Price = re.Monthly_Price,
                    RenewDate = re.RenewDate,
                    TimeCreated = re.TimeCreated,
                    Substate = re.Substate

                }).ToList(),
            };
        }

        public int? UpdateUser(UpdatedUserDto returnedUser , string userID)
        {
            var user = _unitOfWork.UserRepo.GetUser(userID);            
            if (user is null) { return null; }
            if(returnedUser.ProfileImg is not null)
            {
               var imageName = _unitOfWork.SaveImageMethod(returnedUser.ProfileImg);
                user.ProfileImg = imageName;
            }
            user.UserName = returnedUser.UserName;  
            user.Email = returnedUser.Email;
            user.FirstName = returnedUser.FirstName;
            user.LastName = returnedUser.LastName;
            user.Address = returnedUser.Address;

            _unitOfWork.ResturantRepo.SaveChanges();
            return 1;
        }
    }
}
