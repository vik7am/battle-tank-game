using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemyTankAI enemyTankAI;
        private EnemyTankView enemyTankView;
        private TankModel tankModel;
        private TankHealth tankHealth;

        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 position){
            this.enemyTankView = enemyTankView;
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
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
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsAlive())
                return;
            enemyTankView.DestroyTank();
        }
    }
}

