using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.PromotionDto
{
    public class PromotionToEditDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime date { get; set; }
        public IFormFile? Image { get; set; }
        public decimal PriceBefore { get; set; }
        public decimal PriceAfter { get; set; }
    }
}
