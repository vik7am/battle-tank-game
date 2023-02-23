using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float tankSpeed;
    float movement;
    public float rotationSpeed;
    float rotation;
    Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        //movement = Input.GetAxisRaw("VerticalUI");
        //rotation = Input.GetAxisRaw("HorizontalUI");
        movement = joystick.Vertical;
        rotation = joystick.Horizontal;
        if(rotation != 0)
            transform.Rotate(0f, rotation*rotationSpeed, 0f, Space.World);
    }

    void FixedUpdate() {
        rb.velocity = movement * tankSpeed * transform.forward;
    }
}
