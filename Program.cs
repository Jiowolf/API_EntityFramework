
using API_EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


namespace API_EntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // We stock the connection string here
            string? context = builder.Configuration.GetConnectionString("Connection");

            // We create here the service
            builder.Services.AddDbContext<ContextDatabase>(opt => opt.UseSqlServer(context));
            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseSwagger(options =>
                {
                    options.RouteTemplate = "/openapi/{documentName}.json";
                });
                app.MapScalarApiReference();
            }







            app.Run();
        }
    }
}






