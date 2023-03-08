
namespace BattleTank
{
    public struct BulletModel
    {
        public BulletType bulletType;
        public float speed;
        public float damage;
        
        public BulletModel(BulletSO bulletSO){
            bulletType = bulletSO.bulletType;
            speed = bulletSO.speed;
            damage = bulletSO.damage;
        }
    }
}
