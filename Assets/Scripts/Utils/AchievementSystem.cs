using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace BattleTank
{
    public class AchievementSystem : MonoBehaviour
    {
        [SerializeField] private Image image; 
        [SerializeField] private TextMeshProUGUI text;
        private bool achievementPanelActive;
        [SerializeField] private float duration;
        private float elapsedTime;

        [SerializeField] private AchievemntSO bulletFired;
        [SerializeField] private AchievemntSO bulletDodged;
        [SerializeField] private AchievemntSO enemyTankDestroyed;

        void Start()
        {
            HideAchievementPanel();
            TankService.Instance.OnBulletFired += BulletFiredAchievement;
            TankService.Instance.OnBulletHit += EnemyBulletsDodgedAchievement;
            TankService.Instance.OnTankDestroyed += EnemyTankDestroyedAchievement;
        }

        private void Update(){
            if(achievementPanelActive == false)
                return;
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= duration)
                HideAchievementPanel();
        }

        public void ShowAchievement(string title){
            elapsedTime = 0;
            achievementPanelActive = true;
            image.enabled = true;
            text.text = title;
        }

        public void HideAchievementPanel(){
            achievementPanelActive = false;
            image.enabled = false;
            text.text = "";
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
                Debug.Log(title + " || " + description);
                so.currentLevel++;
            }
        }
    }
}
