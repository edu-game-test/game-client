using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Core;
using Game.Services;
using GameShared.Models;
using UnityEngine;

namespace Game.Heroes
{
    public class HeroCollectionManager : MonoBehaviour
    {
        private List<Hero> _heroes = new();

        private async void Start()
        {
            await LoadCollection();
        }

        private async Task LoadCollection()
        {
            var heroes = await ServiceLocator.Get<HeroService>().GetCollectionAsync();
            _heroes = heroes ?? new();
            Debug.Log($"Loaded {_heroes.Count} heroes.");
        }
    }
}
