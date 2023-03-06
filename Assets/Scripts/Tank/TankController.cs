using UnityEngine;

namespace BattleTank
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;

        public TankController(TankModel tankModel){
            this.tankModel = tankModel;
            this.tankView = tankModel.tankView;
            Initialize();
        }

        private void Initialize(){
            tankView = GameObject.Instantiate<TankView>(tankView);
            tankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(tankView.transform);
        }

        public Vector3 GetMovementVelocity(){
            return TankService.Instance.GetJoystickVI() * tankModel.movementSpeed * tankView.transform.forward;
        }

        public float GetRotationAngle(){
            return TankService.Instance.GetJoystickHI() * tankModel.rotationSpeed;
        }
    }
}
