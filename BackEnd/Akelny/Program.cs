
using Akelny.BLL.Services.PromotionServices;
using Akelny.BLL.Services.SectionServices;
using Akelny.DAL.Context;
using Akelny.DAL.Repo.MealRepo;
using Akelny.DAL.Repo.PromotionRepo;
using Akelny.DAL.Repo.SectionRepo;
using Akelny.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Akelny
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion


            #region Database
            var con = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(con));
            #endregion

            #region Repos

            builder.Services.AddScoped<IPromotionRepo , PromotionRepo>();
            builder.Services.AddScoped<ISectionRepo, SectionRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMealRepo,MealRepo>();

            #endregion

            #region Services

            builder.Services.AddScoped<IPromotionServices, PromotionServices>();
            builder.Services.AddScoped<ISectionServices, SectionServices>();
            builder.Services.AddScoped<IMealRepo, MealRepo>();

            #endregion



            var app = builder.Build();

            #region Middleware
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion


        }
    }
}