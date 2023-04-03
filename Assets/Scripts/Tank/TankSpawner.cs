using UnityEngine;

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
        
        public PlayerTankController GetPlayerTankController(Vector3 spawnPosition){
            int tankNo = Random.Range(0, playerTankListSO.playerTankSO.Length);
            PlayerTankModel playerTankmodel = new PlayerTankModel(playerTankListSO.playerTankSO[tankNo]);
            return new PlayerTankController(playerTankmodel, playerTankView, spawnPosition);
        }

        public EnemyTankController GetEnemyTankController(){
            Vector3 spawnPosition;
            if(FindEnemySpawnPosition(out spawnPosition)){
                int tankNo = Random.Range(0, enemyTankListSO.enemyTankSO.Length);
                EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankListSO.enemyTankSO[tankNo]);
                return new EnemyTankController(enemyTankModel, enemyTankView, spawnPosition);
            }
            return null;
        }

        private bool FindEnemySpawnPosition(out Vector3 spawnPosition){
            if(Utility.FindRandomPositionInRange(out spawnPosition, Vector3.zero, spawnRange)){
                spawnPosition.SetYAxisToZero();
                if(OutsidePlayerSafeZone(spawnPosition))
                    return true;
                return false;
            }
            return false;
        }

        private bool OutsidePlayerSafeZone(Vector3 spawnPosition){
            Vector3 playerPosition = TankService.Instance.playerTankController.playerTankView.transform.position;
            playerPosition.SetYAxisToZero();
            if(Vector3.Distance(spawnPosition, playerPosition) > safeZoneRadius)
                return true;
            return false;
        }
    }
}
