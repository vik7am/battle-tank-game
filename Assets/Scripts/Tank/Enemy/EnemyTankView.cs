using System.Collections;
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
        private NavMeshAgent navMeshAgent;
        private Vector3 myDestination = new Vector3(0, 0, -30);

        private void Awake(){
            rb = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void SetTankController(EnemyTankController tankController){
            this.enemyTankController = tankController;
            UpdateTankColor();
        }

        private void UpdateTankColor(){
            Material material = enemyTankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }

        public void Damage(float damage){
            enemyTankController.ReduceHealth(damage);
        }

        public void DestroyTank(){
            Destroy(gameObject);
        }

        private void Update(){
            navMeshAgent.destination = myDestination;
        }
    }
}
