using Lambda_DI_Example.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lambda_DI_Example
{
    public class Startup
    {
        public static IServiceCollection Container => ConfigureServices(LambdaConfiguration.Configuration); 
                
        
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