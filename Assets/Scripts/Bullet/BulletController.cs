using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        BulletModel bulletModel;
        BulletView bulletView;
        public BulletController(BulletModel bulletModel, Transform bullet){
            this.bulletModel = bulletModel;
            this.bulletView = bulletModel.bulletView;
            Instantiate(bullet);
        }

        public void Instantiate(Transform bullet){
            bulletView = GameObject.Instantiate<BulletView>(bulletView, bullet.position, bullet.rotation);
            bulletView.SetBulletController(this);
        }

        public float GetBulletSpeed(){
            return bulletModel.speed;
        }
    }
}
