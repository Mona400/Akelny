﻿using Akelny.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Dto.MealDto
{
    public class MealToAddDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile? Image { get; set; } 
        public decimal? Price { get; set; }
        public int RestaurantId { get; set; }
        //public Restaurant? Restaurant { get; set; }
        public int SectionId { get; set; }
        //public Section? Section { get; set; }
    }
}
