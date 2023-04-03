using UnityEngine.AI;
using UnityEngine;
using System.Collections;

namespace BattleTank
{
    public class EnemySM : StateMachine //Enemy State Machine
    {
        public IdleState idleState {get; private set;}
        public PatrolState patrolState {get; private set;}
        public ChaseState chaseState {get; private set;}
        public AttackState attackState {get; private set;}
        public DeadState deadState {get; private set;}

        public NavMeshAgent navMeshAgent {get; private set;}
        public EnemyTankController enemyTankController {get; private set;}
        public EnemyTankView enemyTankView {get; private set;}
        public float chaseRange {get; private set;}
        public float attackRange {get; private set;}
        [SerializeField] public float enemyPatrolRange = 50;
        [SerializeField] public float fireRateRPM = 30;
        private Coroutine coroutine;
        
        private void Awake() {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyTankView = GetComponent<EnemyTankView>();
        }

        private void Initialize(){
            chaseRange = enemyTankController.enemyTankModel.chaseRange;
            attackRange = enemyTankController.enemyTankModel.attackRange;
            idleState = new IdleState(this);
            patrolState = new PatrolState(this);
            chaseState = new ChaseState(this);
            attackState = new AttackState(this);
            deadState = new DeadState(this);
        }
        
        private void StartEnemySM(){
            SetState(idleState);
        }

        public void SetEnemyTankController(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
            Initialize();
            StartEnemySM();
        }

        private void Update(){
            if(currentState != null)
                currentState.Tick();
        }

        public bool PlayerTankInChaseRange(){
            if(TankService.Instance.IsPlayerTankAlive() == false)
                return false;
            return Vector3.Distance(transform.position, TankService.Instance.GetPlayerTankPosition()) < chaseRange;
        }

        public bool PlayerTankInAttackRange(){
            if(TankService.Instance.IsPlayerTankAlive() == false)
                return false;
            return Vector3.Distance(transform.position, TankService.Instance.GetPlayerTankPosition()) < attackRange;
        }

        public void FindRandomEnemyDestination(){
            if(coroutine == null)
                coroutine = StartCoroutine(FindDestinationCoroutine());
        }

        IEnumerator FindDestinationCoroutine(){
            bool destinationFound = false;
            Vector3 destination;
            do{
                destinationFound =  Utility.FindRandomPositionInRange(out destination, transform.position, enemyPatrolRange);
                yield return null;
            } while(destinationFound == false);
            navMeshAgent.SetDestination(destination);
            coroutine = null;
        }
        
    }
}
