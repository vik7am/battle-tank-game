using UnityEngine;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private Rigidbody rb;

        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        private void Update(){
            if(tankController.GetRotationAngle() != 0){
                transform.Rotate(transform.up, tankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate() {
            rb.velocity = tankController.GetMovementVelocity();
        }
        
        public void SetTankController(TankController tankController){
            this.tankController = tankController;
        }
    }
}
