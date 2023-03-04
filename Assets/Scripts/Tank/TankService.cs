using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    TankModel tankModel;
    TankController tankController;
    [SerializeField] TankView tankView;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    void Start(){
        SpawnTank();
    }

    void SpawnTank(){
        tankModel = new TankModel(movementSpeed, rotationSpeed);
        tankController = new TankController(tankModel, tankView, joystick);
    }
}
