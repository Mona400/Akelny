using Akelny.BLL.Dto.MealDto;
using Akelny.BLL.Dto.PromotionDto;
using Akelny.DAL.Models;
using Akelny.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Akelny.BLL.Dto.ResturantsDto;
using Akelny.BLL.Dto.SectionsDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Akelny.BLL.Services.MealServices
{
    public class MealServices : IMealServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public MealServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddMeal(MealToAddDto mealToAddDto)
        {
            var newName = _unitOfWork.SaveImageMethod(mealToAddDto.Image!);
            var meal = new Meal
            {
                Name = mealToAddDto.Name,
                Description = mealToAddDto.Description,
                Price = mealToAddDto.Price,
                Image = newName,
                RestaurantId = mealToAddDto.RestaurantId,
                SectionId = mealToAddDto.SectionId
            };

            _unitOfWork.MealRepo.Add(meal);
            _unitOfWork.MealRepo.SaveChanges();
        }

        public List<MealDto> GetAll()
        {
            var meals = _unitOfWork.MealRepo.GetAll();

            return meals.Select(m => new MealDto
            {
                Id = m.Id,
                Description = m.Description,
                Name = m.Name,
                Image = m.Image,
                Price = m.Price,
                RestaurantId = m.RestaurantId,
                SectionId = m.SectionId,

            }).ToList();
        }

        public List<MealResturantDto> GetAllByResturantId(int? ResturantId)
        {
            var meals = _unitOfWork.MealRepo.GetAllByResturantId(ResturantId);
            return meals.Select(m => new MealResturantDto
            {
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Image = m.Image,
                Id = m.Id,
                Restaurant = m.Restaurant != null ? new ResturantDto
                {
                    Id = m.Restaurant.Id,
                    Description = m.Restaurant.Description,
                    Rating = m.Restaurant.Rating,
                    Title = m.Restaurant.Title
                } : null,
                Section = m.Section != null ? new SectionDto
                {
                    Id = m.Section.Id,
                    Name = m.Section.Name
                } : null
            }).ToList();
        }

        public List<MealSectionDto> GetAllBySectionId(int? SectionId)
        {
            var meals = _unitOfWork.MealRepo.GetAllBySectionId(SectionId);
            return meals.Select(m => new MealSectionDto
            {
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                Id = m.Id,
                Image = m.Image,
                SectionId = m.SectionId,
                Section = new SectionDto
                {
                    Id = m.Section!.Id,
                    Name = m.Section.Name
                }
            }).ToList();
        }

        public MealDto? GetById(int id)
        {
            Meal? meal = _unitOfWork.MealRepo.GetMealById(id);

            if (meal == null) { return null; }
            var MealDto = new MealDto();
            MealDto.Id = meal.Id;
            MealDto.Description = meal.Description;
            MealDto.Price = meal.Price;
            MealDto.Name = meal.Name;
            MealDto.SectionId = meal.SectionId;
            MealDto.Image = meal.Image;
            MealDto.RestaurantId = meal.RestaurantId;

            return MealDto;
        }

        public void Delete(int id)
        {
            Meal? meal = _unitOfWork.MealRepo.GetById(id);

            if (meal == null) { return; }

            _unitOfWork.MealRepo.Delete(meal);
            _unitOfWork.MealRepo.SaveChanges();
        }

        public void Edit(int id, MealToEditDto mealToEditDto)
        {
            var newName = "";
            if (mealToEditDto.Image is not null)
            {
                newName = _unitOfWork.SaveImageMethod(mealToEditDto.Image!);

            }
            Meal? meal = _unitOfWork.MealRepo.GetById(id);

            if (meal == null) { return; }

            //what if all data is empty
            meal.Id = mealToEditDto.Id;
            meal.Name = mealToEditDto.Name;
            meal.Price = mealToEditDto.Price;
            meal.Description = mealToEditDto.Description;
            meal.SectionId = mealToEditDto.SectionId;
            meal.RestaurantId = mealToEditDto.RestaurantId;
            meal.Image = newName;
            _unitOfWork.MealRepo.Update(meal);
            _unitOfWork.MealRepo.SaveChanges();
        }

        public List<MealDto> GetTopFourMeals()
        {
            var meals = _unitOfWork.MealRepo.GetAll();

            return meals.Select(m => new MealDto
            {
                Id = m.Id,
                Description = m.Description,
                Name = m.Name,
                Image = m.Image,
                Price = m.Price,
                RestaurantId = m.RestaurantId,
                SectionId = m.SectionId,

            }).OrderBy(m => m.Price).Take(4).ToList();
        }
    }



}

