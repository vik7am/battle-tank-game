using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "AchievementSO", menuName ="ScriptableObjects/Achievement")]
    public class AchievementSO : ScriptableObject
    {
        [field: SerializeField]
        public string achievementName {get; private set;}
        [field: SerializeField]
        public AchievementLevel[] level {get; private set;}
    }

    [System.Serializable]
    public struct AchievementLevel{
        public string title;
        public string description;
        public int target;
    }
}
