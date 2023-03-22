using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class TankSpawner : GenericSingleton<TankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Vector3 playerSpawnPosition;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private PlayerTankView playerTankView;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private float spawnRange;
        [SerializeField] private float safeZoneRadius;
        
        public PlayerTankController SpawnPlayerTank(Vector3 spawnPosition){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            return new PlayerTankController(tankModel, playerTankView, spawnPosition);
        }

        public EnemyTankController SpawnEnemyTank(){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            return new EnemyTankController(tankModel, enemyTankView, GetEnemySpawnPosition());
        }

        private Vector3 GetEnemySpawnPosition(){
            bool spawnPointFound = false;
            Vector3 playerPosition = TankService.Instance.playerTankController.playerTankView.transform.position;
            playerPosition = new Vector3(playerPosition.x, 0, playerPosition.z);
            Vector3 spawnPoint = Vector3.zero;
            do{
                spawnPoint = GetRandomSpawnPoint();
                spawnPoint = new Vector3(spawnPoint.x, 0, spawnPoint.z);
                if(Vector3.Distance(spawnPoint, playerPosition) > safeZoneRadius)
                    spawnPointFound = true;
            }while(!spawnPointFound);
            return spawnPoint;
        }

        public Vector3 GetRandomSpawnPoint(){
            bool pointFound = false;
            Vector3 result = Vector3.zero;
            NavMeshHit hit;
            do{
                Vector3 randomPoint = spawnRange * Random.insideUnitSphere;
                if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas)){
                    result = hit.position;
                    pointFound = true;
                }
            }while(pointFound == false);
            return result;
        }
    }
}
