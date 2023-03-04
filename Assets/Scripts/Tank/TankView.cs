using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    public void setTankController(TankController tankController){
        this.tankController = tankController;
    }

    private void Update(){
        tankController.GetPlayerInput();
        if(tankController.GetRotationAngle() != 0){
            transform.Rotate(transform.up, tankController.GetRotationAngle() * Time.deltaTime);
        }
    }

    private void FixedUpdate() {
        rb.velocity = tankController.GetMovementVelocity();
    }
}
