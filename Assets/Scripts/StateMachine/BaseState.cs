namespace BattleTank
{
    public abstract class BaseState
    {
        protected StateMachine stateMachine;

        public BaseState(StateMachine stateMachine){
            this.stateMachine = stateMachine;
        }
        
        public abstract void Tick();
        public virtual void OnStateEnter() {}
        public virtual void OnStateExit() {}
    }
}
