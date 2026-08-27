using System.Collections.Generic;
using System.Threading.Tasks;
using GameShared.DTOs;
using UnityEngine;

namespace Game.Battle
{
    public class BattleAnimator : MonoBehaviour
    {
        public async Task PlayEvents(List<BattleTurnEvent> events)
        {
            foreach (var evt in events)
            {
                Debug.Log($"{evt.SourceHeroId} → {evt.TargetHeroId}: {evt.DamageDealt} dmg (crit: {evt.IsCritical})");
                // Play attack animation, damage number, etc.
                await Task.Delay(500); // placeholder for animation duration
            }
        }
    }
}
