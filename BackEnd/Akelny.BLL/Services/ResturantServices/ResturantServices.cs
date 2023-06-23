using Akelny.BLL.Dto.MealDto;
using Akelny.BLL.Dto.PromotionDto;
using Akelny.BLL.Dto.ResturantsDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
    using Akelny.BLL.Dto.ReviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akelny.BLL.Services.ResturantServices
{
    public class ResturantServices : IResturantServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResturantServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ResturantToAddDto resturantToAddDto)
        {
            var newName = _unitOfWork.SaveImageMethod(resturantToAddDto.Image!);
            var resturant = new Restaurant
            {
                Title = resturantToAddDto.Title,
                Description = resturantToAddDto.Description,
                //MealId = resturantToAddDto.MealId,
                Rating = resturantToAddDto.Rating,
                Speciality = resturantToAddDto.Speciality,
                Image=newName,

            };
            _unitOfWork.ResturantRepo.Add(resturant);
            _unitOfWork.ResturantRepo.SaveChanges();
        }

        public void Delete(int id)
        {
            Restaurant? restaurant = _unitOfWork.ResturantRepo.GetById(id);

            if (restaurant == null) { return; }

            _unitOfWork.ResturantRepo.Delete(restaurant);
            _unitOfWork.ResturantRepo.SaveChanges();
        }

        public void Edit(int id, ResturantToEditDto resturantToEditDto)
        {
            Restaurant? restaurant = _unitOfWork.ResturantRepo.GetById(id);
            var newName = "";
            if (resturantToEditDto.Image is not null)
            {
                newName = _unitOfWork.SaveImageMethod(resturantToEditDto.Image!);

            }

            if (restaurant == null) { return; }

            restaurant.Id = resturantToEditDto.Id;
            restaurant.Description = resturantToEditDto.Description;
            restaurant.Title = resturantToEditDto.Title;
            restaurant.Speciality = resturantToEditDto.Speciality;
            restaurant.Rating = resturantToEditDto.Rating;
            restaurant.Image = newName;

            _unitOfWork.ResturantRepo.Update(restaurant);
            _unitOfWork.ResturantRepo.SaveChanges();
        }

        public List<ResturantDto> GetAll()
        {
            List<Restaurant> restaurants = _unitOfWork.ResturantRepo.GetAll();
            return restaurants.Select(r => new ResturantDto
            {
                Id = r.Id,
                Description = r.Description,
                Rating = r.Rating,

                Speciality = r.Speciality,
                Title = r.Title,
               Image=r.Image

            }).ToList();
        }

        public ResturantDto? GetById(int id)
        {
            Restaurant? restaurant = _unitOfWork.ResturantRepo.GetResturantById(id);
            var meals = _unitOfWork.MealRepo.GetAllByResturantId(id);

       

            if (restaurant == null) { return null; }
            var resturantDto = new ResturantDto();
            resturantDto.Id = restaurant.Id;
            resturantDto.Title = restaurant.Title;
            resturantDto.Description = restaurant.Description;
            resturantDto.Rating = restaurant.Rating;
            resturantDto.Speciality = restaurant.Speciality;
            resturantDto.Image = restaurant.Image!;
            resturantDto.Meal = meals.Take(4).Select(meal => new MealDto
            {
                Description= meal.Description,
                Id= meal.Id,
                Image= meal.Image,
                Name= meal.Name,
                Price= meal.Price,
                RestaurantId= restaurant.Id,
                SectionId = meal.SectionId,
            }).ToList();
            resturantDto.Reviews = restaurant.Reviews?.Select(re => new ReviewDto
            {
                Comment = re.Comment,
                Id = re.Id,
                Impression = re.Impression,
                RestId = re.RestId,
                TimeCreated = re.TimeCreated,
                UserId = re.UserId,
                UserName = re.UserName,
                ProfileImg = re.ProfileImg!
            }).ToList();
            return resturantDto;
        }
    }
}

