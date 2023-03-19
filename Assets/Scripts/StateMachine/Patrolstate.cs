using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class PatrolState : State
    {
        private NavMeshAgent navMeshAgent;

        public PatrolState(EnemyTankController enemyTankController): base(enemyTankController) {
            navMeshAgent = enemyTankController.GetNavMeshAgent();
        }

        public override void OnStateEnter(){
            navMeshAgent.SetDestination(GetRandomPoint(enemyTankController.GetTankPosition(), 50));
            navMeshAgent.isStopped = false;
        }

        public override void Tick(){
            if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                enemyTankController.SetState(new IdleState(enemyTankController));
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
