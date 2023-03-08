using UnityEngine;

namespace BattleTank
{
    public abstract class TankController
    {
        protected TankModel tankModel;
        protected TankView tankView;

        public TankController(TankModel tankModel, TankView tankView){
            this.tankModel = tankModel;
            this.tankView = tankView;
        }

        public Material GetMaterial(){
            return tankModel.material;
        }

        public abstract Vector3 GetMovementVelocity();
        public abstract float GetRotationAngle();
        public abstract void FireBullet();
    }
}
