using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        protected TankModel tankModel;
        [SerializeField] protected Transform spawnPosition;
        [SerializeField] protected TankListSO tankListSO;
        [SerializeField] protected PlayerTankView playerTankView;
        [SerializeField] private GameObject cam;

        private void Start() {
            SpawnTank();
        }

        protected void SpawnTank(){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[2]);
            new PlayerTankController(tankModel, playerTankView, spawnPosition.position);
        }

        public void SetCameraToFollowPlayer(Transform player){
            cam.transform.SetParent(player);
        }
    }
}
