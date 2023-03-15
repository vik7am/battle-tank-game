using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private Rigidbody rb;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;
        private EnemyTankController enemyTankController;
        private NavMeshAgent agent;
        [SerializeField] private float range;

        private void Awake(){
            rb = GetComponent<Rigidbody>();
            agent = GetComponent<NavMeshAgent>();
        }

        public void SetTankController(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
            agent.SetDestination(enemyTankController.GetRandomPoint(transform.position, range));
        }

        private void UpdateTankColor(){
            Material material = enemyTankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }

        public void Damage(float damage){
            enemyTankController.ReduceHealth(damage);
        }

        private void Update(){
            if(agent.remainingDistance <= agent.stoppingDistance)
                agent.SetDestination(enemyTankController.GetRandomPoint(transform.position, range));
        }

        private void OnCollisionEnter(Collision other) {
            IDamageable damagableObject = other.gameObject.GetComponent<IDamageable>();
            if(damagableObject != null)
                damagableObject.Damage(enemyTankController.GetCollisionDamage());
        }
    }
}
