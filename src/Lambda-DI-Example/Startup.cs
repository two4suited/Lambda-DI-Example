using System.IO;
using Lambda_DI_Example.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lambda_DI_Example
{
    public static class Startup
    {
        public static IServiceCollection Container => ConfigureServices(Configuration); 
               
        private static IConfigurationRoot Configuration => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        
        private static IServiceCollection ConfigureServices(IConfigurationRoot root)
        {
            var services = new ServiceCollection();
            services.Configure<Numbers>(options =>
                root.GetSection("numbers").Bind(options));
                    
            services.AddTransient<IMath, Math>();
           
            return services;
        
        }
    }
}