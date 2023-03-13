using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemyTankAI enemyTankAI;
        private EnemyTankView enemyTankView;
        private EnemyTankModel enemyTankModel;
        private TankHealth tankHealth;
        private int currentPathNo;

        public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankView){
            this.enemyTankView = enemyTankView;
            this.enemyTankModel = enemyTankModel;
            tankHealth = new TankHealth(enemyTankModel.health);
            currentPathNo = 0;
            Initialize(enemyTankModel.patrolPath[0]);
        }

        private void Initialize(Vector3 position){
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, Quaternion.identity);
            enemyTankView.SetTankController(this);
        }

        public Material GetMaterial(){
            return enemyTankModel.material;
        }

        public void ReduceHealth(float damage){
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsAlive())
                return;
            enemyTankView.DestroyTank();
        }

        public Vector3 GetNextDestination(){
            currentPathNo = (currentPathNo+1) % enemyTankModel.patrolPath.Length;
            return enemyTankModel.patrolPath[currentPathNo];
        }
    }
}

