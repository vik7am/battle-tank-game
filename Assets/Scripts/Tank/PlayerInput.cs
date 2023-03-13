using UnityEngine;

namespace BattleTank
{
    public class PlayerInput
    {
        private FixedJoystick joystick;
        private float horizontalJI;
        private float verticalJI;

        public PlayerInput(FixedJoystick joystick){
            this.joystick = joystick;
        }

        public float GetPlayerVI(){
            float verticalKI = Input.GetAxisRaw("VerticalUI");
            if(verticalKI != 0)
                return verticalKI;
            return joystick.Vertical;
        }

        public float GetPlayerHI(){
            float horizontalKI = Input.GetAxisRaw("HorizontalUI");
            if(horizontalKI != 0)
                return horizontalKI;
            return joystick.Horizontal;
        }
    }
}
