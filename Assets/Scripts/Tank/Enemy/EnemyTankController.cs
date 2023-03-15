using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class EnemyTankController
    {
        private EnemyTankView enemyTankView;
        private TankModel tankModel;
        private TankHealth tankHealth;

        public EnemyTankController(TankModel tankModel, EnemyTankView enemyTankView, Vector3 spawnPosition){
            this.enemyTankView = enemyTankView;
            this.tankModel = tankModel;
            tankHealth = new TankHealth(tankModel.health);
            Initialize(spawnPosition);
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
            DestroyTank();
        }

        public Vector3 GetRandomPoint(Vector3 center, float range){
            bool pointFound = false;
            Vector3 randomPoint;
            Vector3 result = Vector3.zero;
            NavMeshHit hit;
            do{
                randomPoint = center + Random.insideUnitSphere * range;
                if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas)){
                    result = hit.position;
                    pointFound = true;
                }
            }while(pointFound == false);
            return result;
        }

        public float GetCollisionDamage(){
            return tankModel.damage;
        }

        public bool DestroyTank(){
            if(enemyTankView == null)
                return false;
            GameObject.Destroy(enemyTankView.gameObject);
            enemyTankView = null;
            return true;
        }
    }
}

