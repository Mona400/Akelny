using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
   public class AuthResult
    {
        public string Token { get; set; } = string.Empty;

        public string? Username { get; set; } 
        public string? Email { get; set; }

        public string? ProfileImg { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
        public bool  Result { get; set; }
        public List<string>Errors { get; set; } = new List<string>();
    }
}
