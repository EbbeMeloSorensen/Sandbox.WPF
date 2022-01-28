using System.Threading.Tasks;

namespace AsyncAwait
{
    public class CoffeeService
    {
        public async Task PrepareCoffeeAsync()
        {
            // Asynchronously prepare an awesome coffee
            await Task.Delay(2000);
        }
    }
}