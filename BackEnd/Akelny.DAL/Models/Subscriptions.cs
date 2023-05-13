using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.DAL.Models
{
    public enum Substate
    {
        Pending , Active , Expired
    }
    public class Subscriptions
    {
        public int Id { get; set; }
        public int TestUserID { get; set; }

        public TestUser? user { get; set; }

        public Substate Substate { get; set; }

        [Column(TypeName ="decimal(9,2)")]
        public decimal Monthly_Price { get; set; }

        [Column(TypeName = "datetime2(0)")]
        public DateTime TimeCreated { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime RenewDate { get; set; }

        public ICollection<Meals_Dates>? Meals_Dates { get; set; }

    }
}
