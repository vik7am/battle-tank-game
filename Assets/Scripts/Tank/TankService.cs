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
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            tankController = new PlayerTankController(tankModel);
        }

        public void SetCameraToFollowPlayer(Transform player){
            cam.transform.SetParent(player);
        }

        public float GetPlayerHI(){
            if(Mathf.Abs(joystick.Horizontal) > Mathf.Epsilon)
                return joystick.Horizontal;
            return Input.GetAxisRaw("HorizontalUI");
        }

        public float GetPlayerVI(){
            if(Mathf.Abs(joystick.Vertical) > Mathf.Epsilon)
                return joystick.Vertical;
            return Input.GetAxisRaw("VerticalUI");
        }
    }
}
