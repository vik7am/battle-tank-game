using UnityEngine;

namespace BattleTank
{
    public class IdleState : BaseState
    {
        private float idleTime = 5;
        private float timeElapsed;
        private EnemySM enemySM;

        public IdleState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
        }

        public override void OnStateEnter(){
            timeElapsed = 0;
        }

        public override void Tick(){
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= idleTime)
                stateMachine.SetState(enemySM.patrolState);
        }
    }
}
