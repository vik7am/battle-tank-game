
public class TankModel
{
    float movementSpeed;
    float rotationSpeed;

    public TankModel(float movementSpeed, float rotationSpeed){
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
    }

    public float GetMovementSpeed(){
        return movementSpeed;
    }

    public float GetRotationSpeed(){
        return rotationSpeed;
    }
}
