using UnityEngine;

namespace BattleTank
{
    public class IdleState : State
    {
        private float idleTime = 5;
        private float timeElapsed;

        public IdleState(EnemyTankController enemyTankController): base(enemyTankController) {}

        public override void OnStateEnter(){
            timeElapsed = 0;
        }

        public override void Tick(){
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= idleTime)
                enemyTankController.SetState(new PatrolState(enemyTankController));
        }
    }
}
