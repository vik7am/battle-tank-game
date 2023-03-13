using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemyTankAI enemyTankAI;
        protected EnemyTankView enemyTankView;
        protected TankModel tankModel;
        protected float currentHealth;

        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 position){
            this.enemyTankView = enemyTankView;
            this.tankModel = tankModel;
            currentHealth = tankModel.health;
            Initialize(position);
        }

        private void Initialize(Vector3 position){
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, Quaternion.identity);
            enemyTankView.SetTankController(this);
        }

        public Material GetMaterial(){
            return tankModel.material;
        }

        public void ReduceHealth(float damage){
            currentHealth -= damage;
        }
    }
}

