using API_Application_1.Interfaces;
using API_Application_1.Repository;
using Azure.Identity;
using MongoDB.GenericRepository.Context;
using MongoDB.GenericRepository.Interfaces;
using MongoDB.GenericRepository.Persistence;

namespace API_Application_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //var keyvaultUri =  new Uri("https://KEYNST01.vault.azure.net/");
             
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
           // builder.Configuration.AddAzureKeyVault(keyvaultUri, new DefaultAzureCredential());

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            
            MongoDbPersistence.Configure();
            
            builder.Services.AddSwaggerGen();
            //builder.Services.Configure<AppConfig>(builder.Configuration.Bind);

            builder.Services.AddScoped<IMongoContext, MongoContext>(); 
            builder.Services.AddScoped<IMessageRepository, MessageRepository>(); 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
               
            //}
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}