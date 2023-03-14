using UnityEngine;
using System.Collections.Generic;

namespace BattleTank
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private Vector3[] enemyTankSpawns;
        private List<EnemyTankController> enemyTanks;

        private void Start() {
            SpawnEnemyTanks();
        }

        private void SpawnEnemyTanks(){
            enemyTanks = new List<EnemyTankController>();
            for(int i=0; i< enemyTankSpawns.Length; i++){
                int tankNo = Random.Range(0, tankListSO.tankSO.Length);
                tankModel = new TankModel(tankListSO.tankSO[tankNo]);
                enemyTanks.Add(new EnemyTankController(tankModel, enemyTankView, enemyTankSpawns[i]));
            }
        }

        public void DestroyAllEnemyTanks(){
            for(int i=0; i< enemyTankSpawns.Length; i++){
                enemyTanks[i].DestroyTank();
            }
        }
    }
}
