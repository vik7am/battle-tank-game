using UnityEngine;

namespace BattleTank
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected BaseState currentState;

        public void SetState(BaseState state){
            if(currentState != null){
                currentState.OnStateExit();
            }
            currentState = state;
            if(currentState != null){
                currentState.OnStateEnter();
            }
        }
    }
}
