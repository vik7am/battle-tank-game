using UnityEngine;
namespace BattleTank
{
    public class PlayerTankController : TankController
    {
        public PlayerTankController(TankModel tankModel) : base(tankModel){
            Initialize();
        }

        private void Initialize(){
            tankView = GameObject.Instantiate<TankView>(tankView);
            tankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(tankView.transform);
        }

        public override void FireBullet(){
            BulletService.Instance.SpawnBullet(tankView.bulletSpawPoint.transform);
        }

        public override Vector3 GetMovementVelocity(){
            return TankService.Instance.GetPlayerVI() * tankModel.movementSpeed * tankView.transform.forward;
        }

        public override float GetRotationAngle(){
            return TankService.Instance.GetPlayerHI() * tankModel.rotationSpeed;
        }
    }
}
