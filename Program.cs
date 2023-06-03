using API_Application_1.Interfaces;
using API_Application_1.Model;
using API_Application_1.Repository;
using MongoDB.GenericRepository.Context;
using MongoDB.GenericRepository.Interfaces;
using MongoDB.GenericRepository.Repository;

namespace API_Application_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.Configure<AppConfig>(builder.Configuration.Bind);

            builder.Services.AddScoped<IMongoContext, MongoContext>(); 
            builder.Services.AddScoped<IMessageRepository, MessageRepository>(); 
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

            app.Run();
        }
    }
}