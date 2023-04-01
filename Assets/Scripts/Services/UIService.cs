using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BattleTank
{
    public class UIService : GenericMonoSingleton<UIService>
    {
        [SerializeField] private GameObject achievementPanel;
        [SerializeField] private TextMeshProUGUI titleAP;
        [SerializeField] private TextMeshProUGUI descriptionAP;
        [SerializeField] private FixedJoystick fixedJoystick;
        [SerializeField] private Button fireButton;
        [SerializeField] private GameObject virtualInputUI;
        [SerializeField] private GameObject mainMenuUI;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private Button startButton;
        private Coroutine coroutine;
        private Queue<string> titleQueue;
        private Queue<string> descriptionQueue;
        [SerializeField] bool virtualInputEnabled;

        public static System.Action onFireButtonPressed;

        private void Start() {
            titleQueue = new Queue<string>();
            descriptionQueue = new Queue<string>();
            DestructionService.onDestructionEnd += ShowGameOverUI;
            mainMenuUI.SetActive(true);
            startButton.onClick.AddListener(StartGame);
            fireButton.onClick.AddListener(FireKeyPressed);
        }

        public void StartGame(){
            mainMenuUI.SetActive(false);
            if(virtualInputEnabled)
                virtualInputUI.SetActive(true);
            TankService.Instance.StartGame();
        }

        public void ShowGameOverUI(){
            gameOverUI.SetActive(true);
        }

        public void FireKeyPressed(){
            onFireButtonPressed?.Invoke();
        }

        public bool VirtualJoystickEnabled() {return virtualInputEnabled; }

        public FixedJoystick GetFixedJoystick(){ return fixedJoystick; }

        public Button GetFireButton() {return fireButton; }

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
                yield return new WaitForSeconds(2);
                achievementPanel.SetActive(false);
                yield return new WaitForSeconds(1);
            }
            coroutine = null;
        }
    }
}
