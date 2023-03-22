using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankService : GenericSingleton<TankService>
    {
        public PlayerTankController playerTankController {get; private set;}
        public List<EnemyTankController> enemyTCList {get; private set;}
        [SerializeField] private FixedJoystick fixedJoystick;
        [SerializeField] private float enemyTankCount;
        
        void Start()
        {
            playerTankController = TankSpawner.Instance.SpawnPlayerTank(Vector3.zero);
            enemyTCList = new List<EnemyTankController>();
            for(int i=0; i<enemyTankCount; i++)
                enemyTCList.Add(TankSpawner.Instance.SpawnEnemyTank());
        }

        public FixedJoystick GetFixedJoystick(){
            return fixedJoystick;
        }

        public Vector3 GetPlayerTankPosition(){
            return playerTankController.GetTankPosition();
        }

        public bool IsPlayerTankAlive(){
            return playerTankController.IsTankAlive();
        }

        public void RespawnEnemyTank(){
            if(IsPlayerTankAlive() == true)
                enemyTCList.Add(TankSpawner.Instance.SpawnEnemyTank());
        }
    }
}
