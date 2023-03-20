using UnityEngine;
namespace BattleTank
{
    public class PlayerTankSpawner : GenericSingleton<PlayerTankSpawner>
    {
        private TankModel tankModel;
        [SerializeField] private Vector3 spawnPosition;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private PlayerTankView playerTankView;
        [SerializeField] private FixedJoystick fixedJoystick;
        public PlayerTankController playerTankController {get; private set;}
        
        private void Start() {
            SpawnTank();
        }

        private void SpawnTank(){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            playerTankController = new PlayerTankController(tankModel, playerTankView, spawnPosition, fixedJoystick);
        }
    }
}
