namespace BattleTank
{
    public abstract class State
    {
        protected EnemyTankController enemyTankController;
        protected State currentState;

        public State(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
        }
        public abstract void Tick();
        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}
    }
}
