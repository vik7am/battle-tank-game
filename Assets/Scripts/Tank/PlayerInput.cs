using UnityEngine;

namespace BattleTank
{
    public class PlayerInput : MonoBehaviour
    {
        private FixedJoystick fixedJoystick;
        private bool useVirtualInput;
        private Rigidbody rigidBody;
        private PlayerTankController controller;
        float verticalInput;
        float horizontalInput;

        private void Awake() {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void Start(){
            useVirtualInput = UIService.Instance.virtualInputUI.gameObject.activeSelf;
            if(useVirtualInput){
                fixedJoystick =  UIService.Instance.virtualInputUI.GetFixedJoystick();
                VirtualInputUI.onFireButtonPressed += FireBullet;
            }
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
            if(useVirtualInput){
                verticalInput = fixedJoystick.Vertical;
                horizontalInput = fixedJoystick.Horizontal;
            }
            else{
                verticalInput = Input.GetAxisRaw("VerticalUI");
                horizontalInput = Input.GetAxisRaw("HorizontalUI");
                if(Input.GetKeyDown(KeyCode.Space))
                    controller.FireBullet();
            }
        }

        private void FireBullet(){
            controller.FireBullet();
        }

        private void Update(){
            UpdatePlayerInput();
            UpdateTankRotation();
        }

        private void FixedUpdate(){
            UpdateTankMovement();
        }
    }
}
