using UnityEngine;
using System.Collections;
namespace BattleTank
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private PlayerTankView playerTankView;
        [SerializeField] private GameObject cam;
        [SerializeField] private FixedJoystick fixedJoystick;
        
        private void Start() {
            SpawnTank();
        }

        private void SpawnTank(){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            new PlayerTankController(tankModel, playerTankView, spawnPosition, fixedJoystick);
        }

        public void StartFollowingPlayer(Transform player){
            cam.transform.position = player.position;
            cam.transform.SetParent(player);
        }

        public void StopFollowingPlayer(){
            cam.transform.SetParent(null);
        }
    }
}
