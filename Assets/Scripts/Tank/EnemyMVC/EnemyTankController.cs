using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemySM enemySM;
        public EnemyTankView enemyTankView {get; private set;}
        public EnemyTankModel enemyTankModel {get;}

        public EnemyTankController(EnemyTankModel tankModel, EnemyTankView enemyTankView, Vector3 spawnPosition){
            this.enemyTankView = enemyTankView;
            this.enemyTankModel = tankModel;
            Initialize(spawnPosition);
        }

        private void Initialize(Vector3 position){
            enemyTankView = ObjectPoolService.Instance.enemyTankPool.GetItem();
            enemyTankView.transform.position = position;
            enemyTankView.transform.rotation = Quaternion.identity;
            enemyTankView.SetTankMaterial(enemyTankModel.material);
            enemyTankView.gameObject.SetActive(true);
            enemySM = enemyTankView.GetComponent<EnemySM>();
            enemyTankView.SetTankController(this);
            enemySM.SetEnemyTankController(this);
        }

        public void TakeDamage(TankName shooter, float damage){
            if(enemyTankModel.isAlive == false)
                return;
            enemyTankModel.SetCurrentHealth(enemyTankModel.currentHealth - damage);
            if(enemyTankModel.isAlive == false){
                EventService.Instance.OnTankDestroyed(shooter, TankName.ENEMY_TANK);
                DestroyTank();
            }
        }

        public void DestroyTank(){
            if(enemyTankView == null)
                return;
            enemySM.SetState(enemySM.deadState);
            enemyTankView = null;
        }

    }
}

