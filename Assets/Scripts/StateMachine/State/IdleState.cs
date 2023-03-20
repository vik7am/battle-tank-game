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
            enemySM.navMeshAgent.isStopped = true;
            timeElapsed = 0;
        }

        public override void Tick(){
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= idleTime)
                stateMachine.SetState(enemySM.patrolState);
            if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < 10)
                stateMachine.SetState(enemySM.chaseState);
        }
    }
}
