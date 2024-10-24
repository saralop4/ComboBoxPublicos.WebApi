using ComboBoxPublicos.WebApi.Modules.Injection;
using ComboBoxPublicos.WebApi.Modules.WatchDog;
using WatchDog;

namespace ComboBoxPublicos.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInjection(builder.Configuration);
            builder.Services.AddWatchDog(builder.Configuration);

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("policyApi", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();
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

            app.UseAuthorization();
            app.UseWatchDogExceptionLogger();
            app.UseCors("policyApi");
            app.MapControllers();
            app.UseWatchDog(opt =>
            {
                opt.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
                opt.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
                //opt.WatchPageUsername = "admin";
                //opt.WatchPagePassword = "admin@123";
            });

            app.Run();
        }
    }
}
