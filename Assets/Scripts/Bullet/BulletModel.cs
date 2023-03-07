
namespace BattleTank
{
    public struct BulletModel
    {
        public BulletType bulletType;
        public float speed;
        public float damage;
        public BulletView bulletView;
        public BulletModel(BulletSO bulletSO){
            bulletType = bulletSO.bulletType;
            speed = bulletSO.speed;
            damage = bulletSO.damage;
            bulletView = bulletSO.bulletView;
        }
    }
}
