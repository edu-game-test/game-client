using System.Collections.Generic;
using System.Threading.Tasks;
using GameShared.DTOs;

namespace Game.Services
{
    public class BattleService
    {
        public async Task<BattleResult?> StartBattleAsync(string stageId, List<string> heroIds)
        {
            return await ApiClient.PostAsync<BattleRequest, BattleResult>(
                "/battle/start",
                new BattleRequest
                {
                    StageId = stageId,
                    PartyHeroIds = heroIds,
                    PlayerId = ""
                });
        }

        public async Task<BattleResult?> SubmitTurnAsync(string sessionId, string sourceId, string targetId, string skillId)
        {
            return await ApiClient.PostAsync<BattleTurnRequest, BattleResult>(
                "/battle/turn",
                new BattleTurnRequest
                {
                    BattleSessionId = sessionId,
                    SourceHeroId = sourceId,
                    TargetHeroId = targetId,
                    SkillId = skillId
                });
        }
    }
}
