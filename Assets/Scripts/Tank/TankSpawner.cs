using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class TankSpawner : GenericMonoSingleton<TankSpawner>
    {
        [SerializeField] private Vector3 playerSpawnPosition;
        [SerializeField] private PlayerTankView playerTankView;
        [SerializeField] private PlayerTankListSO playerTankListSO;
        [SerializeField] private EnemyTankView enemyTankView;
        [SerializeField] private EnemyTankListSO enemyTankListSO;
        [SerializeField] private float spawnRange;
        [SerializeField] private float safeZoneRadius;
        
        public PlayerTankController SpawnPlayerTank(Vector3 spawnPosition){
            int tankNo = Random.Range(0, playerTankListSO.playerTankSO.Length);
            PlayerTankModel playerTankmodel = new PlayerTankModel(playerTankListSO.playerTankSO[tankNo]);
            return new PlayerTankController(playerTankmodel, playerTankView, spawnPosition);
        }

        public EnemyTankController SpawnEnemyTank(){
            Vector3 spawnPosition;
            if(GetEnemySpawnPosition(out spawnPosition)){
                int tankNo = Random.Range(0, enemyTankListSO.enemyTankSO.Length);
                EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankListSO.enemyTankSO[tankNo]);
                return new EnemyTankController(enemyTankModel, enemyTankView, spawnPosition);
            }
            return null;
        }

        private bool GetEnemySpawnPosition(out Vector3 spawnPosition){
            if(GetRandomSpawnPosition(out spawnPosition)){
                spawnPosition = new Vector3(spawnPosition.x, 0, spawnPosition.z);
                if(OutsidePlayerSafeZone(spawnPosition))
                    return true;
                return false;
            }
            return false;
        }

        private bool GetRandomSpawnPosition(out Vector3 spawnPosition){
            NavMeshHit hit;
            Vector3 randomPoint = spawnRange * Random.insideUnitSphere;
            if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas)){
                spawnPosition = hit.position;
                return true;
            }
            spawnPosition = Vector3.zero;
            return false;
        }

        private bool OutsidePlayerSafeZone(Vector3 spawnPosition){
            Vector3 playerPosition = TankService.Instance.playerTankController.playerTankView.transform.position;
            playerPosition = new Vector3(playerPosition.x, 0, playerPosition.z);
            if(Vector3.Distance(spawnPosition, playerPosition) > safeZoneRadius)
                return true;
            return false;
        }
    }
}
