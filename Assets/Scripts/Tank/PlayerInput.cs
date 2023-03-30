using UnityEngine;

namespace BattleTank
{
    public class PlayerInput : MonoBehaviour
    {
        private FixedJoystick fixedJoystick;
        [SerializeField] private bool useJoyStick;
        private Rigidbody rigidBody;
        PlayerTankController controller;
        float verticalInput;
        float horizontalInput;

        private void Awake() {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void Start(){
            fixedJoystick =  UIService.Instance.GetFixedJoystick();
            UIService.Instance.SetJoyStickUI(useJoyStick);
        }

        public void SetPlayerTankController(PlayerTankController controller){
            this.controller = controller;
        }

        void UpdateTankMovement(){
            rigidBody.velocity = verticalInput * controller.playerTankModel.movementSpeed * transform.forward;
        }

        private void UpdateTankRotation(){
            if(horizontalInput == 0)
                return;
            transform.Rotate(transform.up, horizontalInput * controller.playerTankModel.rotationSpeed * Time.deltaTime);
        }

        private void UpdatePlayerInput(){
            if(useJoyStick){
                verticalInput = fixedJoystick.Vertical;
                horizontalInput = fixedJoystick.Horizontal;
            }
            else{
                verticalInput = Input.GetAxisRaw("VerticalUI");
                horizontalInput = Input.GetAxisRaw("HorizontalUI");
            }
        }

        private void Update(){
            if(Input.GetKeyDown(KeyCode.Space))
                controller.FireBullet();
            UpdatePlayerInput();
            UpdateTankRotation();
        }

        private void FixedUpdate(){
            UpdateTankMovement();
        }
    }
}
