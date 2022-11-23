using SpaceStationAPI.DataLayer;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.LogicLayer;
using SpaceStationAPI.Models;

namespace SpaceStationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

            builder.Services.AddScoped<INasaLogic, NasaLogic>();
            builder.Services.AddScoped<IRestWorker, RestWorker>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}