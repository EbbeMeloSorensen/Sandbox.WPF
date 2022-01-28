using System.Threading.Tasks;

namespace AsyncAwait
{
    public class HeavyDutyService
    {
        // Dette er et eksempel på en task der bare tager tid men ellers
        // ikke i sig selv involverer kald til en async metode.
        // Det kan så indlejres i en async
        public async Task<double> DoSomeHeavyWork()
        {
            return await Task.Run(() => 
            {
                var result = 0.0;

                for(int i = 0; i < int.MaxValue; i++)
                {
                    result += 1.0;
                }

                return result;
            });
        }
    }
}
