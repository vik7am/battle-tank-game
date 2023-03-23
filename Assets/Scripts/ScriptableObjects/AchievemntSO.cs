using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "AchievemntSO", menuName ="ScriptableObjects/Achievemnt")]
    public class AchievemntSO : ScriptableObject
    {
        public int currentScore;
        public int currentLevel;
        public AchievementLevel[] level;
    }

    [System.Serializable]
    public class AchievementLevel{
        public string title;
        public string description;
        public int target;
    }
}
