using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class BulletService : GenericSingleton<BulletService>
    {
        BulletController bulletController;
        BulletModel bulletModel;
        [SerializeField] BulletView bulletView;

        public void SpawnBullet(Transform bullet){
            bulletModel = new BulletModel(5);
            bulletController = new BulletController(bulletModel, bulletView, bullet);
        }
    }
}
