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
            fireRateRPM = enemySM.fireRateRPM;;
        }

        public override void OnStateEnter() {
            enemySM.navMeshAgent.isStopped = false;
        }

        public override void Tick()
        {
            FireBullet();
            if(enemySM.PlayerTankInAttackRange())
                enemySM.navMeshAgent.SetDestination(TankService.Instance.GetPlayerTankPosition());
            else
                stateMachine.SetState(enemySM.chaseState);
        }

        private void FireBullet(){
            if(coolDownTime > 0){
                coolDownTime -= Time.deltaTime;
                return;
            }
            Vector3 bulletspawn = enemySM.enemyTankView.bulletSpawPoint.transform.position;
            BulletType bulletType = enemySM.enemyTankController.enemyTankModel.bulletType;
            BulletController bulletController = BulletService.Instance.GetBulletController(bulletType);
            bulletController.SetBulletTransform(bulletspawn, enemySM.transform.rotation);
            bulletController.FireBullet(TankId.ENEMY);
            coolDownTime = 1/fireRateRPM * 60; // converting fire rate from minutes to seconds
        }
    }
}
