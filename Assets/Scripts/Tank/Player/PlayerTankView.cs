using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace BattleTank
{
    public class PlayerTankView : MonoBehaviour, IDamageable
    {
        private PlayerTankController playerTankController;
        private Rigidbody rb;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;
        private Coroutine destroyCoroutine;
        
        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        private void UpdateTankColor(){
            Material material = playerTankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }
        
        public void SetTankController(PlayerTankController playerTankController){
            this.playerTankController = playerTankController;
            UpdateTankColor();
        }

        public void Damage(float damage){
            if(playerTankController.IsTankAlive())
                playerTankController.ReduceHealth(damage);
        }

        private void Update(){
            playerTankController.CheckForPlayerInput();
            if(playerTankController.GetRotationAngle() != 0){
                transform.Rotate(transform.up, playerTankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate() {
            rb.velocity = playerTankController.GetMovementVelocity();
        }

        private void OnCollisionEnter(Collision other) {
            IDamageable damagableObject = other.gameObject.GetComponent<IDamageable>();
            if(damagableObject != null)
                damagableObject.Damage(playerTankController.GetCollisionDamage());
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
