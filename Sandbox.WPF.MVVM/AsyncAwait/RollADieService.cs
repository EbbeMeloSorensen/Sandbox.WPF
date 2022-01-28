using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class RollADieService
    {
        public async Task<int> RollADieAsync()
        {
            // Asynchronously roll a die
            await Task.Delay(1000);

            return new Random().Next(1, 7);
        }
    }
}