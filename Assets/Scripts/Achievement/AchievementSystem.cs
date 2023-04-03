using UnityEngine;

namespace BattleTank
{
    public class AchievementSystem : MonoBehaviour
    {
        [SerializeField] private AchievementSO bulletFired;
        [SerializeField] private AchievementSO bulletDodged;
        [SerializeField] private AchievementSO enemyTankDestroyed;
        private AchievementModel bulletFiredModel;
        private AchievementModel bulletDodgedModel;
        private AchievementModel enemyTankDestroyedModel;
        public static event System.Action<string, string> onAchievementUnlocked;
        
        private void Start(){
            bulletFiredModel = new AchievementModel(bulletFired);
            bulletDodgedModel = new AchievementModel(bulletDodged);
            enemyTankDestroyedModel = new AchievementModel(enemyTankDestroyed);
            BulletController.onBulletFired += BulletFiredAchievement;
            BulletController.onBulletHit += EnemyBulletsDodgedAchievement;
            EnemyTankController.onTankDestroyed += EnemyTankDestroyedAchievement;
        }

        private void BulletFiredAchievement(TankId tankId){
            if(tankId == TankId.PLAYER){
                UpdateAchievement(bulletFiredModel);
            }
        }

        private void EnemyTankDestroyedAchievement(TankId shooter){
            if(shooter == TankId.PLAYER){
                UpdateAchievement(enemyTankDestroyedModel);
            }
        }

        private void EnemyBulletsDodgedAchievement(TankId shooter, TankId reciever, float damage){
            if(shooter == TankId.ENEMY && reciever != TankId.PLAYER){
                UpdateAchievement(bulletDodgedModel);
            }
        }

        private void UpdateAchievement(AchievementModel achievementModel){
            int currentLevel = achievementModel.currentLevel;
            if(currentLevel == achievementModel.level.Length) // Achievement's all level completed
                return;
            achievementModel.currentScore++;
            if(achievementModel.currentScore == achievementModel.level[currentLevel].target){
                string title = achievementModel.level[currentLevel].title;
                string description = achievementModel.level[currentLevel].description;
                onAchievementUnlocked?.Invoke(title, description);
                achievementModel.currentLevel++;
            }
        }
    }
}
