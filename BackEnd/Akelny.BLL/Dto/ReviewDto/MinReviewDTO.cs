using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.ReviewDto;

public class MinReviewDTO
{
    public int ID { get; set; }

    public string? Comment { get; set; }

    public string? Impression { get; set; }

    public DateTime? TimeCreated { get; set;}

}
