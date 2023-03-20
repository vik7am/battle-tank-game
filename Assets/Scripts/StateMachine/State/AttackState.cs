using UnityEngine;

namespace BattleTank
{
    public class AttackState : BaseState
    {
        private EnemySM enemySM;
        
        public AttackState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
        }

        public override void OnStateEnter() {
            enemySM.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < 5)
                Debug.Log("Shooting bullet!!");
            else
                stateMachine.SetState(enemySM.chaseState);
        }
    }
}
