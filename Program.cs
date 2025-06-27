
using API_EntityFramework.Data;
using Microsoft.EntityFrameworkCore;


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

            var app = builder.Build();









            app.Run();
        }
    }
}






