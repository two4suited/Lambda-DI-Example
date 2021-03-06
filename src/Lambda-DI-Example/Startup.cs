using System.IO;
using Lambda_DI_Example.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lambda_DI_Example
{
    public static class Startup
    {
        public static IServiceCollection Container => ConfigureServices(Configuration); 
               
        private static IConfigurationRoot Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        
        private static IServiceCollection ConfigureServices(IConfigurationRoot root)
        {
            var services = new ServiceCollection();
            services.Configure<CustomMessage>(options =>
                root.Bind(options));
                    
            services.AddScoped<ICustomClass,CustomClass>();

			services.AddLogging(x =>
            {
                x.AddConsole();
                x.AddAWSProvider();
                x.SetMinimumLevel(LogLevel.Information);
            });
           
            return services;
        
        }
    }
}