using UnityEngine;

namespace BattleTank
{
    public abstract class TankController
    {
        protected TankModel tankModel;
        protected TankView tankView;

        public TankController(TankModel tankModel){
            this.tankModel = tankModel;
            this.tankView = tankModel.tankView;
        }

        public abstract Vector3 GetMovementVelocity();
        public abstract float GetRotationAngle();
        public abstract void FireBullet();
    }
}
