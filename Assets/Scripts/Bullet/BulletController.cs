using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletController
    {
        BulletModel bulletModel;
        BulletView bulletView;
        public BulletController(BulletModel bulletModel, BulletView bulletView, Transform bullet){
            this.bulletModel = bulletModel;
            this.bulletView = GameObject.Instantiate<BulletView>(bulletView, bullet.position, bullet.rotation);
            this.bulletView.SetBulletController(this);
        }

        public float GetBulletSpeed(){
            return bulletModel.speed;
        }
    }
}
