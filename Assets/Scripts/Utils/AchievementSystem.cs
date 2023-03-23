using UnityEngine;

namespace BattleTank
{
    public class AchievementSystem : MonoBehaviour
    {
        [SerializeField] private AchievemntSO bulletFired;
        [SerializeField] private AchievemntSO bulletDodged;
        [SerializeField] private AchievemntSO enemyTankDestroyed;

        void Start(){
            TankService.Instance.OnBulletFired += BulletFiredAchievement;
            TankService.Instance.OnBulletHit += EnemyBulletsDodgedAchievement;
            TankService.Instance.OnTankDestroyed += EnemyTankDestroyedAchievement;
        }

        public void BulletFiredAchievement(TankName tankName){
            if(tankName != TankName.PLAYER_TANK)
                return;
            UpdateAchievement(bulletFired);
        }

        public void EnemyTankDestroyedAchievement(TankName shooter, TankName reciever){
            if(shooter == TankName.PLAYER_TANK && reciever == TankName.ENEMY_TANK){
                UpdateAchievement(enemyTankDestroyed);
            }
        }

        public void EnemyBulletsDodgedAchievement(TankName shooter, TankName reciever){
            if(shooter == TankName.ENEMY_TANK && reciever != TankName.PLAYER_TANK){
                UpdateAchievement(bulletDodged);
            }
        }

        public void UpdateAchievement(AchievemntSO so){
            if(so.currentLevel == so.level.Length)
                return;
            so.currentScore++;
            if(so.currentScore == so.level[so.currentLevel].target){
                string title = so.level[so.currentLevel].title;
                string description = so.level[so.currentLevel].description;
                UIService.Instance.DisplayAchievement(title, description);
                so.currentLevel++;
            }
        }
    }
}
