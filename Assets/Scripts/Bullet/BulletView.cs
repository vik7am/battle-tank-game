using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletView : MonoBehaviour
    {
        BulletController bulletController;
        Rigidbody rb;
        float lifeTime = 5;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        private void FireBullet(){
            rb.velocity = bulletController.GetBulletSpeed() * transform.forward;
        }

        private void Update() {
            lifeTime -= Time.deltaTime;
            if(lifeTime<0){
                Destroy(gameObject);
            }
        }

        public void SetBulletController(BulletController bulletController){
            this.bulletController = bulletController;
            FireBullet();
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<TankView>()){
                TankView tankView = other.GetComponent<TankView>();
                tankView.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
