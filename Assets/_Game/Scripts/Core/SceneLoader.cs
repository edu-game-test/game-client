using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core
{
    public static class SceneLoader
    {
        public static async Task LoadAsync(string sceneName)
        {
            var op = SceneManager.LoadSceneAsync(sceneName);
            while (!op.isDone)
                await Task.Yield();
        }

        public static async Task LoadBattleAsync(string stageId)
        {
            PlayerPrefs.SetString("CurrentStageId", stageId);
            await LoadAsync("Battle");
        }
    }
}
