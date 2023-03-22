using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemySM enemySM;
        public EnemyTankView enemyTankView {get; private set;}
        public TankModel tankModel {get;}
        public TankHealth tankHealth {get;}

        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 spawnPosition){
            this.enemyTankView = enemyTankView;
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 position){
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView, position, Quaternion.identity);
            enemySM = enemyTankView.GetComponent<EnemySM>();
            enemyTankView.SetTankController(this);
            enemySM.SetEnemyTankController(this);
        }

        public void DestroyTank(){
            if(enemyTankView == null)
                return;
            enemySM.SetState(enemySM.deadState);
            enemyTankView = null;
        }

        public bool IsTankAlive(){
            return !tankHealth.IsDead();
        }

    }
}

