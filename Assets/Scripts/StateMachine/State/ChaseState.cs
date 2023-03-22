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
            if(enemySM.PlayerTankInAttackRange())
                stateMachine.SetState(enemySM.attackState);
            else if(enemySM.PlayerTankInChaseRange())
                enemySM.navMeshAgent.SetDestination(enemySM.playerTransform.position);
            else
                stateMachine.SetState(enemySM.idleState);
        }
    }
}
