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
        private int bulletFiredCounter;
        private int enemyTankDestroyedCounter;
        private int enemyBulletsDodgedCounter;

        void Start()
        {
            bulletFiredCounter = 0;
            enemyTankDestroyedCounter = 0;
            enemyBulletsDodgedCounter = 0;
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
            switch(++bulletFiredCounter){
                case 2: ShowAchievement("2 Bullets Fired!"); break;
                case 5: ShowAchievement("5 Bullets Fired!"); break;
                case 10: ShowAchievement("10 Bullets Fired!"); break;
            }
        }

        public void EnemyTankDestroyedAchievement(TankName shooter, TankName reciever){
            if(shooter == TankName.PLAYER_TANK && reciever == TankName.ENEMY_TANK){
                switch(++enemyTankDestroyedCounter){
                    case 2: ShowAchievement("2 Tanks Destroyed!"); break;
                    case 5: ShowAchievement("5 Tanks Destroyed!"); break;
                    case 10: ShowAchievement("10 Tanks Destroyed!"); break;
                }
            }
        }

        public void EnemyBulletsDodgedAchievement(TankName shooter, TankName reciever){
            if(shooter == TankName.ENEMY_TANK && reciever != TankName.PLAYER_TANK){
                switch(++enemyBulletsDodgedCounter){
                    case 2: ShowAchievement("2 bullets Dodged!"); break;
                    case 5: ShowAchievement("5 bullets Dodged!"); break;
                    case 10: ShowAchievement("10 bullets Dodged!"); break;
                }
            }
        }
    }
}
