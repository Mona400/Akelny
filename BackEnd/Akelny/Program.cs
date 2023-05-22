
using Akelny.BLL.Services.MealServices;
using Akelny.BLL.Services.PromotionServices;
using Akelny.BLL.Services.ResturantServices;
using Akelny.BLL.Services.SectionServices;
using Akelny.BLL.Services.SubService;
using Akelny.DAL.Context;
using Akelny.DAL.Repo.MealRepo;
using Akelny.DAL.Repo.PromotionRepo;
using Akelny.DAL.Repo.ResturantRepo;
using Akelny.DAL.Repo.SectionRepo;
using Akelny.DAL.Repo.SubRepo;
using Akelny.DAL.UnitOfWork;
using Akelny.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

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

            #region JWTConfig
            builder.Services.Configure<JWT>(builder.Configuration.GetSection(key: "JWTConfig"));
            var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key: "JWTConfig:Secret").Value);
            var tokenValidationParameter= new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,//for dev
                ValidateAudience = false,//for dev
                RequireExpirationTime = false,//for dev -->need to update after refresh toked added
                ValidateLifetime = true

            };
            #endregion

            #region JWT Services
            builder.Services.AddAuthentication(options=>{
                options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(jwt =>
            {
               
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameter;
            });

            builder.Services.AddSingleton(tokenValidationParameter);
            //builder.Services.def<IdentityUser>();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
         .AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion
            #region Repos

            builder.Services.AddScoped<IPromotionRepo , PromotionRepo>();
            builder.Services.AddScoped<ISectionRepo, SectionRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IMealRepo,MealRepo>();
            builder.Services.AddScoped<IResturantRepo, ResturantRepo>();
            builder.Services.AddScoped<ISubRepo, SubRepo>();
            #endregion

            #region Services

            builder.Services.AddScoped<IPromotionServices, PromotionServices>();
            builder.Services.AddScoped<ISectionServices, SectionServices>();
            builder.Services.AddScoped<IMealServices, MealServices>();
            builder.Services.AddScoped<IResturantServices, ResturantServices>();
            builder.Services.AddScoped<ISubService, SubService>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
            #endregion


        }
    }
}