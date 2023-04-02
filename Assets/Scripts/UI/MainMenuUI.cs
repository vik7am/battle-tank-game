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
        private bool useVirtualInput;
        private bool isAudioEnabled;


        private void Start(){
            startButton.onClick.AddListener(StartGame);
            inputSelectionButton.onClick.AddListener(SwitchPlayerInput);
            audioStatusButton.onClick.AddListener(ToggleAudioSource);
            SwitchPlayerInput();
            ToggleAudioSource();
        }

        private void SwitchPlayerInput(){
            useVirtualInput = !useVirtualInput;
            inputSelection.text = (useVirtualInput)? "Joystick": "Keyboard";
        }

        private void ToggleAudioSource(){
            isAudioEnabled = !isAudioEnabled;
            audioSource.enabled = isAudioEnabled;
            audioStatus.text = (isAudioEnabled)? "Audio On": "Audio Off";
            
        }

        private void StartGame(){
            if(useVirtualInput){
                UIService.Instance.ShowVirtualInputUI();
            }
            TankService.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}
