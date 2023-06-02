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
                IsEmailVerified = user.IsEmailVerified,
                ProfileImg = user.ProfileImg,
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
    }
}
