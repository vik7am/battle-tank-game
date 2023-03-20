using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class PatrolState : BaseState
    {
        private EnemySM enemySM;
        private NavMeshAgent navMeshAgent;

        public PatrolState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
            this.navMeshAgent = enemySM.navMeshAgent;
        }

        public override void OnStateEnter(){
            navMeshAgent.SetDestination(enemySM.GetRandomPoint(enemySM.transform.position, 50));
            navMeshAgent.isStopped = false;
        }

        public override void Tick(){
            if(enemySM.playerTransform != null)
                if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < 15)
                    stateMachine.SetState(enemySM.chaseState);
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                navMeshAgent.SetDestination(enemySM.GetRandomPoint(enemySM.transform.position, 50));
        }
    }
}
