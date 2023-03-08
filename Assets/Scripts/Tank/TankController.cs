using UnityEngine;

namespace BattleTank
{
    public abstract class TankController
    {
        protected TankModel tankModel;
        protected TankView tankView;
        protected float currentHealth;

        public TankController(TankModel tankModel, TankView tankView){
            this.tankModel = tankModel;
            this.tankView = tankView;
            currentHealth = tankModel.health;
        }

        public Material GetMaterial(){
            return tankModel.material;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
            if(currentHealth <= 0)
                tankView.DestroyTank();
        }

        public abstract Vector3 GetMovementVelocity();
        public abstract float GetRotationAngle();
        public abstract void FireBullet();
    }
}
