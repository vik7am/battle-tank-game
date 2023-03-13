using UnityEngine;

namespace BattleTank
{
    public class BulletView : MonoBehaviour
    {
        BulletController bulletController;
        Rigidbody rb;

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
                IDamageable tankView = other.GetComponent<IDamageable>();
                tankView.Damage(bulletController.GetBulletDamage());
            }
            Destroy(gameObject);
        }
    }
}
