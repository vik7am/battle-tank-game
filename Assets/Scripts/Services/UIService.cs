using UnityEngine;
using UnityEngine.UI;

namespace BattleTank
{
    public class UIService : GenericMonoSingleton<UIService>
    {
        [field: SerializeField] public MainMenuUI mainMenuUI {get; private set;}
        [field: SerializeField] public VirtualInputUI virtualInputUI {get; private set;}
        [field: SerializeField] public HeadsUpDisplayUI headsUpDisplayUI {get; private set;}
        [field: SerializeField] public GameOverUI gameOverUI {get; private set;}

        private void Start() {
            mainMenuUI.gameObject.SetActive(true);
            DestructionService.onDestructionStart += HideHeadsUpDisplayUI;
            DestructionService.onDestructionEnd += ShowGameOverUI;
            PlayerTankController.onTankDestroyed += HideVirtualInputUI;
        }

        public void ShowHeadsUpDisplayUI(){
            headsUpDisplayUI.gameObject.SetActive(true);
        }

        public void HideHeadsUpDisplayUI(){
            headsUpDisplayUI.gameObject.SetActive(false);
        }

        private void ShowGameOverUI(){
            gameOverUI.gameObject.SetActive(true);
        }

        public void ShowVirtualInputUI(){
            virtualInputUI.gameObject.SetActive(true);
        }

        public void HideVirtualInputUI(TankId tank){
            virtualInputUI.gameObject.SetActive(false);
        }
        
    }
}
