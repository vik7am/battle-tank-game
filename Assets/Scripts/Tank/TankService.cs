using UnityEngine;

namespace BattleTank
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankModel tankModel;
        private TankController tankController;
        [SerializeField] private GameObject cam;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private TankListSO tankListSO;

        private void Start(){
            SpawnTank();
        }

        private void SpawnTank(){
            tankModel = new TankModel(tankListSO.tankSO[0]);
            tankController = new TankController(tankModel);
        }

        public void SetCameraToFollowPlayer(Transform player){
            cam.transform.SetParent(player);
        }

        public float GetJoystickHI(){
            return joystick.Horizontal;
        }

        public float GetJoystickVI(){
            return joystick.Vertical;
        }
    }
}
