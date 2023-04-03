using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace BattleTank
{
    public class TankService : GenericMonoSingleton<TankService>
    {
        public PlayerTankController playerTankController {get; private set;}
        public List<EnemyTankController> enemyTCList {get; private set;}
        [SerializeField] private float enemyTankCount;
        
        public void StartGame(){
            playerTankController = TankSpawner.Instance.GetPlayerTankController(Vector3.zero);
            enemyTCList = new List<EnemyTankController>();
            for(int i=0; i<enemyTankCount; i++){
                StartCoroutine(SpawnEnemyTankCoroutine());
            }
            EnemyTankController.onTankDestroyed += EnemyTankDestroyed;
        }

        public Vector3 GetPlayerTankPosition(){
            return playerTankController.playerTankView.GetTankPosition();
        }

        public bool IsPlayerTankAlive(){
            return playerTankController.playerTankModel.isAlive;
        }

        private void EnemyTankDestroyed(TankId shooter){
            if(IsPlayerTankAlive() == true){
                StartCoroutine(SpawnEnemyTankCoroutine());
            }
        }

        IEnumerator SpawnEnemyTankCoroutine(){
            EnemyTankController enemyTankController = null;
            do{
                enemyTankController = TankSpawner.Instance.GetEnemyTankController();
                yield return null;
            }while(enemyTankController == null);
            enemyTCList.Add(enemyTankController);
        }
    }
}
