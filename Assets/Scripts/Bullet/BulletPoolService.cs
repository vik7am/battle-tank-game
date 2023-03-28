using System.Collections.Generic;

namespace BattleTank
{
    public class BulletPoolService : GenericSingleton<BulletPoolService>
    {
        private Queue<BulletView> bulletPool;
        public BulletView prefab;

        private void Start() {
            bulletPool = new Queue<BulletView>();
        }

        public BulletView GetBullet(){
            if(bulletPool.Count == 0)
                return CreateNewBullet();
            return bulletPool.Dequeue();
        }

        public BulletView CreateNewBullet(){
            BulletView bulletView = Instantiate<BulletView>(prefab);
            bulletView.gameObject.SetActive(false);
            return bulletView;
        }

        public void ReturnBullet(BulletView bulletView){
            bulletPool.Enqueue(bulletView);
        }
    }
}
