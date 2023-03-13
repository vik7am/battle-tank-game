using UnityEngine;

namespace BattleTank
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private EnemyTankModel enemyTankModel;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private TankPatrolPathListSO paths;

        private void Start() {
            SpawnEnemyTanks();
        }

        private void SpawnEnemyTanks(){
            for(int i=0; i<paths.patrolPathList.Length; i++){
                int tankNo = Random.Range(0, tankListSO.tankSO.Length);
                enemyTankModel = new EnemyTankModel(tankListSO.tankSO[tankNo], paths.patrolPathList[i]);
                new EnemyTankController(enemyTankModel, enemyTankView);
            }
            
        }
    }
}
