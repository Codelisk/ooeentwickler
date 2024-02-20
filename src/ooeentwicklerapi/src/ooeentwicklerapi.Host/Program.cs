
using Framework.Restservice.Repositories;
using Framework.Restservice.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ooeentwicklerapi.Database;
using ooeentwicklerapi.Foundation;
using Microsoft.EntityFrameworkCore;

namespace ooeentwicklerapi.Host
{
    public partial class Program : BaseProgram
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureDatabase(builder);

            builder.Services.ConfigureAllServices<DtoEntityProfile, OoeDbContext>();
            builder.Services.InitModules();
            //builder.Services.ConfigureAllServices<DtoEntityProfile, OoeDbContext>();
            
            builder.Build().ConfigureAndStartApp();
        }
        public static void ConfigureDatabase(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddTransient<DbContext, OoeDbContext>();
            builder.Services.AddDbContext<OoeDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString, x => x.MigrationsAssembly("ooeentwicklerapi.Host"));
                //opt.UseMySql(connectionString, new MariaDbServerVersion("15.1"), x => x.MigrationsAssembly("Backend.Host"));
                //opt.UseSqlite(connectionString, b => b.MigrationsAssembly("ooeentwicklerapi.Host"));
            });
        }
    }
}
