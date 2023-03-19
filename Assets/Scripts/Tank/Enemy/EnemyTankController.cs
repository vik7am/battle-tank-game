using UnityEngine;
using UnityEngine.AI;


namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemyTankView enemyTankView;
        private TankModel tankModel;
        private TankHealth tankHealth;
        private State currentState;
        private NavMeshAgent navMeshAgent;

        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 spawnPosition){
            this.enemyTankView = enemyTankView;
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 position){
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, Quaternion.identity);
            navMeshAgent = enemyTankView.GetComponent<NavMeshAgent>();
            enemyTankView.SetTankController(this);
            SetState(new IdleState(this));
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

        public NavMeshAgent GetNavMeshAgent(){
            return navMeshAgent;
        }

        public Vector3 GetTankPosition(){
            return enemyTankView.transform.position;
        }

        public void SetState(State state){
            if(currentState != null)
                currentState.OnStateExit();
            currentState = state;
            if(currentState != null)
                currentState.OnStateEnter();
        }

        public State getCurrentstate(){
            return currentState;
        }

    }
}

