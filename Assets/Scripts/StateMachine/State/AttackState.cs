using UnityEngine;

namespace BattleTank
{
    public class AttackState : BaseState
    {
        private EnemySM enemySM;
        private float fireRateRPM;
        private float coolDownTime;
        
        public AttackState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
            fireRateRPM = 30;
        }

        public override void OnStateEnter() {
            enemySM.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            if(enemySM.playerTransform == null){
                stateMachine.SetState(enemySM.idleState);
                return;
            }
            if(Vector3.Distance(enemySM.transform.position, enemySM.playerTransform.position) < enemySM.attackRange)
                enemySM.navMeshAgent.SetDestination(enemySM.playerTransform.position);
            else
                stateMachine.SetState(enemySM.chaseState);
            if(coolDownTime > 0)
                coolDownTime -= Time.deltaTime;
            else{
                BulletService.Instance.SpawnBullet(enemySM.enemyTankView.bulletSpawPoint.transform.position, enemySM.transform.rotation, enemySM.enemyTankController.tankModel.bulletType);
                coolDownTime = 1/fireRateRPM * 60;
            }
                
        }
    }
}
