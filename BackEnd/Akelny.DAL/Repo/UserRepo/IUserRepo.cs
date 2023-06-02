using Akelny.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.UserRepo;

public interface IUserRepo
{
    public bool Register(User _user, string userType, string password);
    public  Task<AuthResult> GenerateJwtToken(IdentityUser user);

    public  AuthResult Login(string email, string password);

    public User? GetUser(string id);

    public string RandomStringGenerator(int length);
}
