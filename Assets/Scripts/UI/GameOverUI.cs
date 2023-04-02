using UnityEngine;
using TMPro;

namespace BattleTank
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI finalScore;

        public void SetFinalScore(float score)
        {
            finalScore.text = "Your Score " + (int)score;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
