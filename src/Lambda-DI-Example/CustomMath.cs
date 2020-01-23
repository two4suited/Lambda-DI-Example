using Lambda_DI_Example.Config;
using Microsoft.Extensions.Options;

namespace Lambda_DI_Example
{
    public class CustomClass : ICustomClass
    {
        private readonly IOptions<CustomMessage> _message;
        
        
        public CustomClass(IOptions<CustomMessage> message)
        {
            _message = message;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }

        public string Message()
        {
            return _message.Value.Message;
        }
    }
}