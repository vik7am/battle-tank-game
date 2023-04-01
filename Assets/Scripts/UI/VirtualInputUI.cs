using UnityEngine;
using UnityEngine.UI;

namespace BattleTank
{
    public class VirtualInputUI : MonoBehaviour
    {
        [SerializeField] public FixedJoystick fixedJoystick;
        [SerializeField] private Button fireButton;
        public static event System.Action onFireButtonPressed;

        private void Start(){
            fireButton.onClick.AddListener(FireKeyPressed);
        }

        private void FireKeyPressed(){
            onFireButtonPressed?.Invoke();
        }

        public FixedJoystick GetFixedJoystick(){ return fixedJoystick; }

        public Button GetFireButton() {return fireButton; }
        
    }
}
