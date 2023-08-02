using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web.Data;
using Web.Services;

namespace Web
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserService, UserService>();

            var connection = builder.Configuration.GetConnectionString("MyConnection");
            builder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseNpgsql(connection);
                options.EnableDetailedErrors(true);
                options.EnableSensitiveDataLogging(true);
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var apiInfo = new OpenApiInfo { Title = "Web", Version = "v1" };
                options.SwaggerDoc("v1", apiInfo);

                var filePath = Path.Combine(AppContext.BaseDirectory, $"{apiInfo.Title}.xml");
                options.IncludeXmlComments(filePath);
            });

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