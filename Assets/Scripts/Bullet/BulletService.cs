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

        public void SpawnBullet(Vector3 bulletSP, Quaternion bulletQ, BulletType bulletType){
            
            for(int i=0; i<bulletListSO.bulletSO.Length; i++)
                if(bulletListSO.bulletSO[i].bulletType == bulletType)
                    bulletModel = new BulletModel(bulletListSO.bulletSO[i]);
            bulletController = new BulletController(bulletModel, bulletView , bulletSP, bulletQ);
        }
    }
}
