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
            if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < 10)
                stateMachine.SetState(enemySM.attackState);
            else if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < 15)
                enemySM.navMeshAgent.SetDestination(enemySM.playerTransform.position);
            else
                stateMachine.SetState(enemySM.idleState);
        }
    }
}
