using UnityEngine;
using UnityEngine.AI;


namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemyTankView enemyTankView;
        private TankModel tankModel;
        private TankHealth tankHealth;
        private NavMeshAgent navMeshAgent;
        private EnemySM enemySM;

        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 spawnPosition){
            this.enemyTankView = enemyTankView;
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 position){
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, Quaternion.identity);
            navMeshAgent = enemyTankView.GetComponent<NavMeshAgent>();
            enemySM = enemyTankView.GetComponent<EnemySM>();
            enemyTankView.SetTankController(this);
        }

        public Material GetMaterial(){
            return tankModel.material;
        }

        public void ReduceHealth(float damage){
            tankHealth.ReduceHealth(damage);
            if(tankHealth.IsDead())
                DestroyTank();
        }

        public float GetCollisionDamage(){
            return tankModel.damage;
        }

        private void DestroyTank(){
            if(enemyTankView == null)
                return;
            navMeshAgent.isStopped = true;
            enemyTankView.ShowEffectAndDestroy();
            enemyTankView = null;
        }

        public void KillTank(){
            tankHealth.ReduceHealth(tankModel.health);
            DestroyTank();
        }

        public bool IsTankAlive(){
            return !tankHealth.IsDead();
        }

    }
}

