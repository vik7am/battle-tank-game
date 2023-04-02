namespace BattleTank
{
    public interface IDamageable{
        public void Damage(TankId tankId, float damage);
        public TankId GetTankId();
    }
}
