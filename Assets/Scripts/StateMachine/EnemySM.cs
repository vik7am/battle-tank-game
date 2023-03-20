using UnityEngine.AI;
using UnityEngine;

namespace BattleTank
{
    public class EnemySM : StateMachine
    {
        public IdleState idleState {get; private set;}
        public PatrolState patrolState {get; private set;}
        public ChaseState chaseState {get; private set;}
        public AttackState attackState {get; private set;}
        public NavMeshAgent navMeshAgent {get; private set;}
        public Transform playerTransform {get; private set;}
        public EnemyTankController enemyTankController {get; private set;}
        public EnemyTankView enemyTankView {get; private set;}
        
        private void Awake() {
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemyTankView = GetComponent<EnemyTankView>();
        }
        
        private void Start(){
            playerTransform = PlayerTankSpawner.Instance.playerTankController.playerTankView.transform;
            idleState = new IdleState(this);
            patrolState = new PatrolState(this);
            chaseState = new ChaseState(this);
            attackState = new AttackState(this);
            SetState(idleState);
        }

        public void SetEnemyTankController(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
        }

        private void Update(){
            currentState.Tick();
        }

        public Vector3 GetRandomPoint(Vector3 center, float range){ // Update function later
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
