using UnityEngine;

namespace BattleTank
{
    public class DeadState : BaseState
    {
        private float despawnTime;
        private float timeElapsed;
        private EnemySM enemySM;

        public DeadState(EnemySM enemySM): base(enemySM) {
            this.enemySM = enemySM;
            despawnTime = 1;
        }

        public override void OnStateEnter(){
            enemySM.navMeshAgent.isStopped = true;
            ParticleEffectService.Instance.ShowTankExplosionEffect(enemySM.transform.position);
            timeElapsed = 0;
        }

        public override void OnStateExit(){
            GameObject.Destroy(enemySM.gameObject);
            TankService.Instance.RespawnEnemyTank();
        }

        public override void Tick(){
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= despawnTime)
                stateMachine.SetState(null);
        }
    }
}
