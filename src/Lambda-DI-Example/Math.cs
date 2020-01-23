using Lambda_DI_Example.Config;
using Microsoft.Extensions.Options;

namespace Lambda_DI_Example
{
    public class Math : IMath
    {
        private readonly IOptions<Numbers> _numbers;

        public Math(IOptions<Numbers> numbers)
        {
            _numbers = numbers;
        }
        public int Add(int a, int b)
        {
            return a + b;
        }
        
    }
}