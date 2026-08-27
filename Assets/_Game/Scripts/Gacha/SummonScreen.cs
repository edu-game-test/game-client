using System.Threading.Tasks;
using Game.Core;
using Game.Services;
using GameShared.DTOs;
using UnityEngine;

namespace Game.Gacha
{
    public class SummonScreen : MonoBehaviour
    {
        public async Task OnSummonSinglePressed()
        {
            var result = await ServiceLocator.Get<SummonService>().SummonSingleAsync();
            if (result is not null)
                DisplayResult(result);
        }

        public async Task OnSummonMultiPressed()
        {
            var result = await ServiceLocator.Get<SummonService>().SummonMultiAsync();
            if (result is not null)
                DisplayResult(result);
        }

        private void DisplayResult(SummonResult result)
        {
            foreach (var hero in result.Heroes)
                Debug.Log($"Summoned: {hero.HeroName} ({hero.Rarity}) — new: {hero.IsNew}");
        }
    }
}
