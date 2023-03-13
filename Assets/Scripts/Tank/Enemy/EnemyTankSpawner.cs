using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyTankSpawner : GenericSingleton<EnemyTankSpawner>
    {
        protected TankModel tankModel;
        [SerializeField] protected Transform spawnPosition;
        [SerializeField] protected TankListSO tankListSO;
        [SerializeField] protected EnemyTankView enemyTankView;

        private void Start() {
            SpawnTank();
        }

        protected void SpawnTank(){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[0]);
            new EnemyTankController(tankModel, enemyTankView, spawnPosition.position);
        }
    }
}
