using UnityEngine;

namespace BattleTank
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private Vector3[] enemyTankSpawns;

        private void Start() {
            SpawnEnemyTanks();
        }

        private void SpawnEnemyTanks(){
            for(int i=0; i< enemyTankSpawns.Length; i++){
                int tankNo = Random.Range(0, tankListSO.tankSO.Length);
                tankModel = new TankModel(tankListSO.tankSO[tankNo]);
                new EnemyTankController(tankModel, enemyTankView, enemyTankSpawns[i]);
            }
        }
    }
}
