using UnityEngine;

namespace BattleTank
{
    public class ChaseState : BaseState
    {
        private EnemySM enemySM;
        
        public ChaseState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
        }

        public override void OnStateEnter() {
            enemySM.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < enemySM.attackRange)
                stateMachine.SetState(enemySM.attackState);
            else if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < enemySM.chaseRange)
                enemySM.navMeshAgent.SetDestination(enemySM.playerTransform.position);
            else
                stateMachine.SetState(enemySM.idleState);
        }
    }
}
