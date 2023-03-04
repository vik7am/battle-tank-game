using UnityEngine;

public class TankController
{
    float tankSpeed;
    float rotationSpeed;
    float movementInput;
    float rotationInput;
    FixedJoystick joystick;
    TankModel tankModel;
    TankView tankView;
    
    public TankController(TankModel tankModel, TankView tankView, FixedJoystick joystick){
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        this.tankView.setTankController(this);
        this.joystick = joystick;
    }

    public void GetPlayerInput(){
        movementInput = joystick.Vertical;
        rotationInput = joystick.Horizontal;
    }

    public Vector3 GetMovementVelocity(){
        return movementInput * tankModel.GetMovementSpeed() * tankView.transform.forward;
    }

    public float GetRotationAngle(){
        return rotationInput * tankModel.GetRotationSpeed();
    }
}
