using Akelny.DAL.Context;
using Akelny.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Repo.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        public UserRepo(UserManager<User> userManager , ApplicationDbContext context)
        {
            _userManager= userManager;
            _context= context;
        }

        public Task<AuthResult> GenerateJwtToken(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public  User? GetUser(string id)
        {
            var _user = _context.Users.Where(en => en.Id == id)
                .Include(en => en.Reviews)
                .Include(en => en.subscriptions)
                
                .SingleOrDefault();

         
            return _user;
        }

        public AuthResult Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public string RandomStringGenerator(int length)
        {
            throw new NotImplementedException();
        }

        public bool Register(User _user, string userType, string password)
        {
            throw new NotImplementedException();
        }
    }
}
