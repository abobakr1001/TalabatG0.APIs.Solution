using Microsoft.EntityFrameworkCore;
using TalabatG0.APIs.Helpers;
using TalabatG02.Core.Repositories;
using TalabatG02.Repository;
using TalabatG02.Repository.Data;

namespace TalabatG0.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StoreContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IGenericRepostory<>),typeof(GenericRepostory<>));

            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // update database works with DI
            var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                   var dbContext = services.GetRequiredService<StoreContext>();
                  await dbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(dbContext); // Json File
            }
            catch (Exception ex)
            {
                var Ilogger  = LoggerFactory.CreateLogger<Program>();
                Ilogger.LogError(ex, "error message during apply the migration");
            }
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(); // files 

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}