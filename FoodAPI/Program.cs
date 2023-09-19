using FoodAPI.Data;
using FoodAPI.Repository;
using FoodAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FoodAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddDbContext<FoodApiDBContext> (
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
                );

            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
            builder.Services.AddScoped<IAdressRepo, AdressRepo>();
            builder.Services.AddScoped<ICouponRepo, CouponRepo>();
            builder.Services.AddScoped<IMenuRepo, MenuRepo>();
            builder.Services.AddScoped<IDelivererRepo, DelivererRepo>();
            builder.Services.AddScoped<IOrderRepo, OrderRepo>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}