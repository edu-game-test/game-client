using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Config")]
    public class GameConfig : ScriptableObject
    {
        public string ServerUrl = "http://localhost:5000";
    }
}
