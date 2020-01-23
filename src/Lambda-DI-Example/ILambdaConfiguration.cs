using Microsoft.Extensions.Configuration;

namespace Lambda_DI_Example
{
        public interface  ILambdaConfiguration
        {
            IConfigurationRoot Configuration { get; }
        }
    
}