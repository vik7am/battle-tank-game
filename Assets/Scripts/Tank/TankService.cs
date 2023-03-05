using UnityEngine;

namespace BattleTank
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankModel tankModel;
        private TankController tankController;
        [SerializeField] private TankView tankView;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;

        private void Start(){
            SpawnTank();
        }

        private void SpawnTank(){
            tankModel = new TankModel(movementSpeed, rotationSpeed);
            tankController = new TankController(tankModel, tankView);
        }

        public float GetJoystickHI(){
            return joystick.Horizontal;
        }

        public float GetJoystickVI(){
            return joystick.Vertical;
        }
    }
}
