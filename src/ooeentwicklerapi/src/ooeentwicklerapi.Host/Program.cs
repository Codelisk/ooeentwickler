
using Framework.Restservice.Database;
using Framework.Restservice.Server;
using ooeentwicklerapi.Database;
using ooeentwicklerapi.Foundation;

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
            builder.Build().ConfigureAndStartApp();
        }
        public static void ConfigureDatabase(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<OoeDbContext>(opt =>
            {
                //opt.UseMySql(connectionString, new MariaDbServerVersion("15.1"), x => x.MigrationsAssembly("Backend.Host"));
                //opt.UseSqlite(connectionString);
            });
        }
    }
}
