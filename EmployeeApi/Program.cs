
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
         options.AddDefaultPolicy( p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddDbContext<EmpDataContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("EmpDataContext")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseAuthorization();

            

            app.MapControllers();

            app.Run();
        }
    }
}
