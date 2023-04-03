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

        public void SetVelocity(Vector3 velocity){
            rb.velocity = velocity;
        }

        public void SetBulletController(BulletController bulletController){
            this.bulletController = bulletController;
        }

        private void OnTriggerEnter(Collider other) {
            bulletController.BulletCollision(other);
        }
    }
}
