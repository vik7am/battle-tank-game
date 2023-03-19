using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace BattleTank
{
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private Rigidbody rb;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;
        private EnemyTankController enemyTankController;
        [SerializeField] private float range;
        private Coroutine destroyCoroutine;

        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        public void SetTankController(EnemyTankController enemyTankController){
            this.enemyTankController = enemyTankController;
            UpdateTankColor();
        }

        private void UpdateTankColor(){
            Material material = enemyTankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }

        public void Damage(float damage){
            if(enemyTankController.IsTankAlive())
                enemyTankController.ReduceHealth(damage);
        }

        private void Update(){
            enemyTankController.getCurrentstate().Tick();
        }

        private void OnCollisionEnter(Collision other){
            IDamageable damagableObject = other.gameObject.GetComponent<IDamageable>();
            if(damagableObject != null)
                damagableObject.Damage(enemyTankController.GetCollisionDamage());
        }

        public void ShowEffectAndDestroy(){
            if(destroyCoroutine != null)
                return;
            destroyCoroutine = StartCoroutine(DestroyEnemyTank());
            ParticleEffectService.Instance.ShowTankExplosionEffect(transform.position);
            
        }

        IEnumerator DestroyEnemyTank(){
            yield return new WaitForSeconds(1.0f);
            Destroy(gameObject);
        }
    }
}
