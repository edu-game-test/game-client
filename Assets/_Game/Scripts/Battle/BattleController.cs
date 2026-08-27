using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Core;
using Game.Services;
using GameShared.DTOs;
using GameShared.Enums;
using UnityEngine;

namespace Game.Battle
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private BattleAnimator animator = null!;

        private string _sessionId = string.Empty;
        private BattleService _battleService = null!;

        private async void Start()
        {
            _battleService = ServiceLocator.Get<BattleService>();
            var stageId = PlayerPrefs.GetString("CurrentStageId");
            // Hero IDs would come from party selection screen
            var partyIds = new List<string>();
            await StartBattle(stageId, partyIds);
        }

        private async Task StartBattle(string stageId, List<string> heroIds)
        {
            var result = await _battleService.StartBattleAsync(stageId, heroIds);
            if (result is null) return;

            _sessionId = result.BattleSessionId;
            await animator.PlayEvents(result.Events);

            if (result.Status == BattleStatus.InProgress) return;
            HandleBattleEnd(result);
        }

        private void HandleBattleEnd(BattleResult result)
        {
            Debug.Log($"Battle ended: {result.Status}");
            // Show victory/defeat screen
        }
    }
}
