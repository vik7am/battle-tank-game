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
        [SerializeField] BulletListSO bulletListSO;

        public void SpawnBullet(Transform bullet){
            bulletModel = new BulletModel(bulletListSO.bulletSO[0]);
            bulletController = new BulletController(bulletModel, bullet);
        }
    }
}
