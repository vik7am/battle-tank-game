using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BattleTank
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private TextMeshProUGUI inputSelection;
        [SerializeField] private Button inputSelectionButton;
        [SerializeField] private TextMeshProUGUI audioStatus;
        [SerializeField] private Button audioStatusButton;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private bool useVirtualInput;
        [SerializeField] private bool isAudioEnabled;


        private void Start(){
            startButton.onClick.AddListener(StartGame);
            inputSelectionButton.onClick.AddListener(SwitchPlayerInput);
            audioStatusButton.onClick.AddListener(ToggleAudioSource);
            audioSource.enabled = isAudioEnabled;
            UpdateUIButton();
        }

        private void SwitchPlayerInput(){
            useVirtualInput = !useVirtualInput;
            UpdateUIButton();
        }

        private void ToggleAudioSource(){
            isAudioEnabled = !isAudioEnabled;
            audioSource.enabled = isAudioEnabled;
            UpdateUIButton();
        }

        private void UpdateUIButton(){
            inputSelection.text = (useVirtualInput)? "Joystick": "Keyboard";
            audioStatus.text = (isAudioEnabled)? "Audio On": "Audio Off";
        }

        private void StartGame(){
            if(useVirtualInput){
                UIService.Instance.ShowVirtualInputUI();
            }
            UIService.Instance.ShowHeadsUpDisplayUI();
            TankService.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}
