using UnityEngine;

namespace BattleTank
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Transform spawnPosition;
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
            new PlayerTankController(tankModel, playerTankView, spawnPosition.position, fixedJoystick);
        }

        public void SetCameraToFollowPlayer(Transform player){
            cam.transform.position = player.position;
            cam.transform.SetParent(player);
        }
    }
}
