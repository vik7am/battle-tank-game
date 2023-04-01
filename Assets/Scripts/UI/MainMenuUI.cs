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
        private bool virtualInputEnabled;
        private bool audioEnabled;


        private void Start(){
            startButton.onClick.AddListener(StartGame);
            inputSelectionButton.onClick.AddListener(UpdateInput);
            audioStatusButton.onClick.AddListener(UpdateAudioStatus);
            UpdateInput();
            UpdateAudioStatus();
        }

        private void UpdateInput(){
            virtualInputEnabled = !virtualInputEnabled;
            if(virtualInputEnabled)
                inputSelection.text = "Joystick";
            else
                inputSelection.text = "Keyboard";
        }

        private void UpdateAudioStatus(){
            audioEnabled = !audioEnabled;
            audioSource.enabled = audioEnabled;
            if(audioEnabled)
                audioStatus.text = "Audio On";
            else
                audioStatus.text = "Audio Off";
        }

        private void StartGame(){
            if(virtualInputEnabled){
                UIService.Instance.ShowVirtualInputUI();
            }
            TankService.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}
