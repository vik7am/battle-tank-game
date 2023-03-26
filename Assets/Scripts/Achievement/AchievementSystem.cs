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
        
        private void Start(){
            bulletFiredModel = new AchievementModel(bulletFired);
            bulletDodgedModel = new AchievementModel(bulletDodged);
            enemyTankDestroyedModel = new AchievementModel(enemyTankDestroyed);
            EventService.Instance.onBulletFired += BulletFiredAchievement;
            EventService.Instance.onBulletHit += EnemyBulletsDodgedAchievement;
            EventService.Instance.onTankDestroyed += EnemyTankDestroyedAchievement;
        }

        private void BulletFiredAchievement(TankName tankName){
            if(tankName != TankName.PLAYER_TANK)
                return;
            UpdateAchievement(bulletFiredModel);
        }

        private void EnemyTankDestroyedAchievement(TankName shooter, TankName reciever){
            if(shooter == TankName.PLAYER_TANK && reciever == TankName.ENEMY_TANK){
                UpdateAchievement(enemyTankDestroyedModel);
            }
        }

        private void EnemyBulletsDodgedAchievement(TankName shooter, TankName reciever){
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
                UIService.Instance.DisplayAchievement(title, description);
                achievementModel.currentLevel++;
            }
        }
    }
}
