using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BattleTank
{
    public class UIService : GenericSingleton<UIService>
    {
        [SerializeField] private GameObject achievementPanel;
        [SerializeField] private TextMeshProUGUI titleAP;
        [SerializeField] private TextMeshProUGUI descriptionAP;
        private Coroutine coroutine;
        private Queue<string> titleQueue;
        private Queue<string> descriptionQueue;

        private void Start() {
            titleQueue = new Queue<string>();
            descriptionQueue = new Queue<string>();
        }

        public void DisplayAchievement(string title, string description){
            titleQueue.Enqueue(title);
            descriptionQueue.Enqueue(description);
            if(coroutine == null)
                coroutine = StartCoroutine(DisplayAchievementPanel());
        }

        IEnumerator DisplayAchievementPanel(){
            while(titleQueue.Count > 0){
                titleAP.text = titleQueue.Dequeue();
                descriptionAP.text = descriptionQueue.Dequeue();
                achievementPanel.SetActive(true);
                yield return new WaitForSeconds(2);
                achievementPanel.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            coroutine = null;
        }
    }
}
