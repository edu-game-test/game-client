using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetaFramework.Unity.Core
{
    public static class SceneLoader
    {
        public static async Task LoadAsync(string sceneName)
        {
            var op = SceneManager.LoadSceneAsync(sceneName);
            while (!op.isDone)
                await Task.Yield();
        }
    }
}
