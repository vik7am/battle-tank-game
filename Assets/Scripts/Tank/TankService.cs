using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankService : GenericMonoSingleton<TankService>
    {
        public PlayerTankController playerTankController {get; private set;}
        public List<EnemyTankController> enemyTCList {get; private set;}
        [SerializeField] private float enemyTankCount;
        
        private void Start(){
            playerTankController = TankSpawner.Instance.SpawnPlayerTank(Vector3.zero);
            enemyTCList = new List<EnemyTankController>();
            for(int i=0; i<enemyTankCount; i++){
                enemyTCList.Add(TankSpawner.Instance.SpawnEnemyTank());
            }
            EnemyTankController.onTankDestroyed += EnemyTankDestroyed;
        }

        public Vector3 GetPlayerTankPosition(){
            return playerTankController.playerTankView.GetTankPosition();
        }

        public bool IsPlayerTankAlive(){
            return playerTankController.playerTankModel.isAlive;
        }

        private void EnemyTankDestroyed(TankName shooter){
            if(IsPlayerTankAlive() == true){
                RespawnEnemyTank();
            }
                
        }

        private void RespawnEnemyTank(){
            enemyTCList.Add(TankSpawner.Instance.SpawnEnemyTank());
        }
    }
}
