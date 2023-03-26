namespace BattleTank
{
    public class AchievementModel
    {
        public int currentScore;
        public int currentLevel;
        public AchievementLevel[] level {get;}

        public AchievementModel(AchievementSO achievemntSO){
            currentScore = 0;
            currentLevel = 0;
            level = achievemntSO.level;
        }
    }
}
