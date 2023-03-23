using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleTank
{
    public class TankService : GenericSingleton<TankService>
    {
        public PlayerTankController playerTankController {get; private set;}
        public List<EnemyTankController> enemyTCList {get; private set;}
        [SerializeField] private FixedJoystick fixedJoystick;
        [SerializeField] private float enemyTankCount;

        public event Action<TankName> OnBulletFired;
        public event Action<TankName, TankName> OnTankDestroyed;
        public event Action<TankName, TankName> OnBulletHit;
        
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

        public void BulletFired(TankName tankName){
            OnBulletFired?.Invoke(tankName);
        }

        public void TankDestroyed(TankName shooter, TankName reciever){
            OnTankDestroyed?.Invoke(shooter, reciever);
        }

        public void BulletHit(TankName shooter, TankName reciever){
            OnBulletHit?.Invoke(shooter, reciever);
        }
    }
}
