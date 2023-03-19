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
            navMeshAgent.SetDestination(GetRandomPoint(enemySM.transform.position, 50));
            navMeshAgent.isStopped = false;
        }

        public override void Tick(){
            if(navMeshAgent.remainingDistance <= enemySM.navMeshAgent.stoppingDistance)
                enemySM.SetState(enemySM.idleState);
        }

        public override void OnStateExit(){
            navMeshAgent.isStopped = true;
        }

        public Vector3 GetRandomPoint(Vector3 center, float range){
            bool pointFound = false;
            Vector3 randomPoint;
            Vector3 result = Vector3.zero;
            NavMeshHit hit;
            do{
                randomPoint = center + Random.insideUnitSphere * range;
                if(NavMesh.SamplePosition(randomPoint, out hit, 1, NavMesh.AllAreas)){
                    result = hit.position;
                    pointFound = true;
                }
            }while(pointFound == false);
            return result;
        }
    }
}
