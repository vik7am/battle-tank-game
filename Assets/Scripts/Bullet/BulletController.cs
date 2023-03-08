using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        BulletModel bulletModel;
        BulletView bulletView;
        public BulletController(BulletModel bulletModel,BulletView bulletView, Vector3 bulletSP, Quaternion bulletQ){
            this.bulletModel = bulletModel;
            this.bulletView = bulletView;
            Instantiate(bulletSP, bulletQ);
        }

        public void Instantiate(Vector3 bulletSPos, Quaternion bulletQ){
            bulletView = GameObject.Instantiate<BulletView>(bulletView, bulletSPos, bulletQ);
            bulletView.SetBulletController(this);
        }

        public float GetBulletSpeed(){
            return bulletModel.speed;
        }

        public float GetBulletDamage(){
            return bulletModel.damage;
        }
    }
}
