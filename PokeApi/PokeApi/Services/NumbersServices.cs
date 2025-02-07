
using PokeApi.Shared.Services;

namespace PokeApi.Services
{
    public class NumbersServices : INumbersServicesShared
    {
        public async Task<int[]> GetNumbersAsync()
        {
            return Enumerable.Range(1, 10).ToArray();
        }

    }
}
