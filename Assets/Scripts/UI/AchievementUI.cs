using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleTank
{
    public class AchievementUI : MonoBehaviour
    {
        [SerializeField] private GameObject achievementPanel;
        [SerializeField] private TextMeshProUGUI titleAP;
        [SerializeField] private TextMeshProUGUI descriptionAP;
        [SerializeField] private float delay;
        private Coroutine coroutine;
        private Queue<string> titleQueue;
        private Queue<string> descriptionQueue;
        
        private void Start(){
            titleQueue = new Queue<string>();
            descriptionQueue = new Queue<string>();
            AchievementSystem.onAchievementUnlocked += DisplayAchievement;
        }

        // Adds achievement data in queue and starts a new coroutine if previous one is finished
        public void DisplayAchievement(string title, string description){
            titleQueue.Enqueue(title);
            descriptionQueue.Enqueue(description);
            if(coroutine == null){
                coroutine = StartCoroutine(DisplayAchievementPanel());
            }
        }
        
        // reads achievemnts form queue and display on the UI.
        IEnumerator DisplayAchievementPanel(){
            while(titleQueue.Count > 0){
                titleAP.text = titleQueue.Dequeue();
                descriptionAP.text = descriptionQueue.Dequeue();
                achievementPanel.SetActive(true);
                yield return new WaitForSeconds(delay);
                achievementPanel.SetActive(false);
                yield return new WaitForSeconds(delay);
            }
            coroutine = null;
        }
        
    }
}
