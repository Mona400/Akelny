using Akelny.DAL.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
    public enum Gender
    {
        male,
        female,
    }
  
    public class User:IdentityUser
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsEmailVerified { get; set; }
        public string UserType { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public string ?Address { get; set; } = string.Empty;
        public ICollection<Subscriptions> subscriptions { get; set; } =new HashSet<Subscriptions>();

        //public ICollection<Reviews> Reviews { get; set; } = new HashSet<Subscriptions>();
    }
}
