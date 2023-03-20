using UnityEngine;

namespace BattleTank
{
    public class IdleState : BaseState
    {
        private float idleTime;
        private float timeElapsed;
        private EnemySM enemySM;

        public IdleState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
            idleTime = 3;
        }

        public override void OnStateEnter(){
            enemySM.navMeshAgent.isStopped = true;
            timeElapsed = 0;
        }

        public override void Tick(){
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= idleTime)
                stateMachine.SetState(enemySM.patrolState);
            if(enemySM.playerTransform != null)
                if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < enemySM.chaseRange)
                    stateMachine.SetState(enemySM.chaseState);
        }
    }
}
