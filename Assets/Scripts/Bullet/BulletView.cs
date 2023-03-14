using UnityEngine;

namespace BattleTank
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        private Rigidbody rb;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        private void FireBullet(){
            rb.velocity = bulletController.GetBulletSpeed() * transform.forward;
        }

        public void SetBulletController(BulletController bulletController){
            this.bulletController = bulletController;
            FireBullet();
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<IDamageable>() != null){
                IDamageable damagableObject = other.GetComponent<IDamageable>();
                damagableObject.Damage(bulletController.GetBulletDamage());
            }
            Destroy(gameObject);
        }
    }
}
