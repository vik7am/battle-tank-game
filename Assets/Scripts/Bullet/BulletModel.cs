namespace BattleTank
{
    public struct BulletModel
    {
        public BulletType bulletType {get;}
        public float speed {get;}
        public float damage {get;}
        
        public BulletModel(BulletSO bulletSO){
            bulletType = bulletSO.bulletType;
            speed = bulletSO.speed;
            damage = bulletSO.damage;
        }
    }
}
