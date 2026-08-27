using System.Collections.Generic;
using System.Threading.Tasks;
using GameShared.Models;

namespace Game.Services
{
    public class HeroService
    {
        public Task<List<Hero>?> GetCollectionAsync() =>
            ApiClient.GetAsync<List<Hero>>("/heroes");

        public Task<Hero?> GetHeroAsync(string id) =>
            ApiClient.GetAsync<Hero>($"/heroes/{id}");
    }
}
