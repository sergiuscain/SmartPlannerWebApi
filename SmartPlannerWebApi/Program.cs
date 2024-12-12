
using Microsoft.EntityFrameworkCore;
using SmartPlannerWebApi.DataBase;
using SmartPlannerWebApi.StaticDataForTesting;

namespace SmartPlannerWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MSSQLDBContext>(options =>
                            options.UseSqlServer(connection));
            
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<INotesStorage, NotesStorage>();

            builder.Services.AddCors(opt =>
                opt.AddPolicy("AllowAllOnly3000port", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3000");
                })
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("AllowAllOnly3000port");
            app.Run();
        }
    }
}
