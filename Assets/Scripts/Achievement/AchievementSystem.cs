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

        private void BulletFiredAchievement(TankName tankName){
            if(tankName != TankName.PLAYER_TANK)
                return;
            UpdateAchievement(bulletFiredModel);
        }

        private void EnemyTankDestroyedAchievement(TankName shooter){
            if(shooter == TankName.PLAYER_TANK){
                UpdateAchievement(enemyTankDestroyedModel);
            }
        }

        private void EnemyBulletsDodgedAchievement(TankName shooter, TankName reciever, float damage){
            if(shooter == TankName.ENEMY_TANK && reciever != TankName.PLAYER_TANK){
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
