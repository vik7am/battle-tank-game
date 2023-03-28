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

        public void SetVelocity(float speed){
            rb.velocity = speed * transform.forward;
        }

        public void SetBulletController(BulletController bulletController){
            this.bulletController = bulletController;
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<IDamageable>() != null){
                IDamageable damagableObject = other.GetComponent<IDamageable>();
                damagableObject.Damage(bulletController.tankName, bulletController.bulletModel.damage);
                EventService.Instance.OnBulletHit(bulletController.tankName, damagableObject.GetTankName());
            }
            else
                EventService.Instance.OnBulletHit(bulletController.tankName, TankName.NONE);
            BulletPoolService.Instance.ReturnItem(this);
            gameObject.SetActive(false);
            
        }
    }
}
