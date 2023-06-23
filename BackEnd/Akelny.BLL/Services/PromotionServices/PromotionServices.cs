using Akelny.BLL.Dto.PromotionDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.PromotionServices
{
    public class PromotionServices : IPromotionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public PromotionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
   
        public void Add(PromotionToAddDto PromotionDto)
        {
            var newName = _unitOfWork.SaveImageMethod(PromotionDto.Image);

            var promotion = new Promotion
            {
               
                Description = PromotionDto.Description,
                Title = PromotionDto.Title,
                date = PromotionDto.date,
               
                PriceAfter = PromotionDto.PriceAfter,
                PriceBefore = PromotionDto.PriceBefore,
                ImageUrl=newName
            };

            _unitOfWork.PromotionRepo.Add(promotion);
            _unitOfWork.PromotionRepo.SaveChanges();
        }

       

        public void Delete(int id)
        {
            Promotion? promotion = _unitOfWork.PromotionRepo.GetById(id);

            if (promotion == null) { return ; }

            _unitOfWork.PromotionRepo.Delete(promotion);
            _unitOfWork.PromotionRepo.SaveChanges();
        
        }

        public void Edit(int id, PromotionToEditDto promotionDto)
        {
            var newName = _unitOfWork.SaveImageMethod(promotionDto.Image);
            Promotion? promotion = _unitOfWork.PromotionRepo.GetById(id);
            if (promotion == null) { return ; }

            promotion.Title = promotionDto.Title;
            promotion.Description = promotionDto.Description;
            promotion.date = promotionDto.date;
          
            promotion.PriceBefore = promotionDto.PriceBefore;
            promotion.PriceAfter = promotionDto.PriceAfter;
            promotion.ImageUrl = newName;
            _unitOfWork.PromotionRepo.Update(promotion);
            _unitOfWork.PromotionRepo.SaveChanges();

        }

        public List<PromotionDto> GetAll()
        {
            List<Promotion> Promotions = _unitOfWork.PromotionRepo.GetAll();
            return Promotions
                .Select(d => new PromotionDto
                {
                    Id=d.Id,
                    Description = d.Description,
                    Title= d.Title,
                    date=d.date,
                   
                    ImageUrl=d.ImageUrl,
                    PriceAfter= d.PriceAfter,
                    PriceBefore= d.PriceBefore,
                 
                    

                })
                .ToList();
        }

        public Promotion? GetById(int id)
        {
            Promotion? promotion = _unitOfWork.PromotionRepo.GetById(id);

            if (promotion == null) { return null; }

            _unitOfWork.PromotionRepo.GetById(id);
            _unitOfWork.PromotionRepo.SaveChanges();
            return promotion;
        }
    }
}
