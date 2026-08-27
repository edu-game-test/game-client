using System.Threading.Tasks;
using GameShared.DTOs;

namespace Game.Services
{
    public class SummonService
    {
        public Task<SummonResult?> SummonSingleAsync() =>
            ApiClient.PostAsync<object, SummonResult>("/summon/single", new { });

        public Task<SummonResult?> SummonMultiAsync() =>
            ApiClient.PostAsync<object, SummonResult>("/summon/multi", new { });
    }
}
