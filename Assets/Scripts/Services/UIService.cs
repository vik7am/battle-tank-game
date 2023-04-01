using UnityEngine;
using UnityEngine.UI;

namespace BattleTank
{
    public class UIService : GenericMonoSingleton<UIService>
    {
        [field: SerializeField] public MainMenuUI mainMenuUI {get; private set;}
        [field: SerializeField] public VirtualInputUI virtualInputUI {get; private set;}
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private Button startButton;

        private void Start() {
            mainMenuUI.gameObject.SetActive(true);
            DestructionService.onDestructionEnd += ShowGameOverUI;
        }

        private void ShowGameOverUI(){
            gameOverUI.SetActive(true);
        }

        public void ShowVirtualInputUI(){
            virtualInputUI.gameObject.SetActive(true);
        }
        
    }
}
