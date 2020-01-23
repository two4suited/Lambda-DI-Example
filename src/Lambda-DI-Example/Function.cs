using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda_DI_Example
{
    public class Function
    {
        private ServiceCollection _serviceCollection;
        
        public Function()
        {
            ConfigureService();
        }

        private void ConfigureService()
        {
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddTransient<IMath,Math>();
        }

        public string FunctionHandler(string input, ILambdaContext context)
        {
            using (ServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider())
            {
                // entry to run app.
                return serviceProvider.GetService<Math>().Add(1,2).ToString();
            }
        }
    }
}
