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
            for(int i=0; i<enemyTankCount; i++)
                enemyTCList.Add(TankSpawner.Instance.SpawnEnemyTank());
            EventService.Instance.onTankDestroyed += TankDestroyed;
        }

        public Vector3 GetPlayerTankPosition(){
            return playerTankController.GetTankPosition();
        }

        public bool IsPlayerTankAlive(){
            return playerTankController.IsTankAlive();
        }

        private void TankDestroyed(TankName shooter, TankName reciever){
            if(reciever == TankName.ENEMY_TANK)
                RespawnEnemyTank();
        }

        private void RespawnEnemyTank(){
            if(IsPlayerTankAlive() == true)
                enemyTCList.Add(TankSpawner.Instance.SpawnEnemyTank());
        }

        
    }
}
