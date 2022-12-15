using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Abstractons;
using Services.Implementations;

namespace HomeWork2
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
        }

        //public static IServiceCollection AddService(this IServiceCollection services,IConfiguration configuration)
        //{
        //    var applicationSettings = configuration.Get<ApplicationSettings>();
        //    services.AddSingleton(applicationSettings);
        //    return services.AddSingleton((IConfigurationRoot)configuration)
        //        .InstallServices()
        //}


        //private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        //{
        //    serviceCollection
        //        .AddTransient<IUserService, UserService>()
        //        .AddTransient<IProductService,ProductService>
        //}

        //public class ApplicationSettings
        //{
        //    public string ConnectionString { get; set; }
        //}
    }
}
