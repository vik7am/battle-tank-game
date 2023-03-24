using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace BattleTank
{
    public class PlayerTankView : MonoBehaviour, IDamageable
    {
        private PlayerTankController playerTankController;
        private Rigidbody rb;
        private Coroutine destroyCoroutine;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;
        
        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        private void UpdateTankColor(){
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = playerTankController.playerTankModel.material;
        }
        
        public void SetTankController(PlayerTankController playerTankController){
            this.playerTankController = playerTankController;
            UpdateTankColor();
        }

        public void Damage(TankName shooter, float damage){
            playerTankController.TakeDmage(shooter, damage);
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

        public TankName GetTankName(){
            return TankName.PLAYER_TANK;
        }
    }
}
