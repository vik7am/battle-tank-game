using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController : TankController
    {
        public PlayerTankController(TankModel tankModel, TankView tankView) : base(tankModel, tankView){
            Initialize();
        }

        private void Initialize(){
            tankView = GameObject.Instantiate<TankView>(tankView);
            tankView.SetTankController(this);
            TankService.Instance.SetCameraToFollowPlayer(tankView.transform);
        }

        public override void FireBullet(){
            Vector3 bulletSPos = tankView.bulletSpawPoint.transform.position;
            Quaternion bulletQ = tankView.bulletSpawPoint.transform.rotation;
            BulletService.Instance.SpawnBullet(bulletSPos, bulletQ, tankModel.bulletType);
        }

        public override Vector3 GetMovementVelocity(){
            return TankService.Instance.GetPlayerVI() * tankModel.movementSpeed * tankView.transform.forward;
        }

        public override float GetRotationAngle(){
            return TankService.Instance.GetPlayerHI() * tankModel.rotationSpeed;
        }
    }
}
