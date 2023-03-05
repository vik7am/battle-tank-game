using UnityEngine;

namespace BattleTank
{
    public class TankController
    {
        private float tankSpeed;
        private float rotationSpeed;
        private float movementInput;
        private float rotationInput;
        private TankModel tankModel;
        private TankView tankView;

        public TankController(TankModel tankModel, TankView tankView){
            this.tankModel = tankModel;
            this.tankView = GameObject.Instantiate<TankView>(tankView);
            this.tankView.SetTankController(this);
        }

        public Vector3 GetMovementVelocity(){
            return TankService.Instance.GetJoystickVI() * tankModel.movementSpeed * tankView.transform.forward;
        }

        public float GetRotationAngle(){
            return TankService.Instance.GetJoystickHI() * tankModel.rotationSpeed;
        }
    }
}
