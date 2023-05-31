using Akelny.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.SubDto;

public class MinSubDTO
{
    public int ID { get; set; }

    public decimal Monthly_Price { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime RenewDate { get; set; }

    public Substate Substate { get; set; }
}
