using UnityEngine;
using TMPro;

namespace BattleTank
{
    public class HeadsUpDisplayUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerHealth;
        [SerializeField] private TextMeshProUGUI playerScore;

        private void Awake() {
            PlayerTankController.onPlayerStatsUpdate += UpdateHUD;
        }

        void UpdateHUD(float health, float score){
            playerHealth.text = "HP " + (int)health;
            playerScore.text = "Score " + (int)score;
        }
    }
}
