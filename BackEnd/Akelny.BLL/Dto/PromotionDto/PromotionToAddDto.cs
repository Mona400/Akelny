using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.PromotionDto
{
    public class PromotionToAddDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public int days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public decimal PriceBefore { get; set; }
        public decimal PriceAfter { get; set; }
    }
}
