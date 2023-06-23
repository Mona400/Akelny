using Akelny.BLL.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.UserService;

public interface IUserService
{
    public ReturnedUserDTO? GetUserDTO(string id);

    public int? UpdateUser(UpdatedUserDto returnedUser , string userID);
}
