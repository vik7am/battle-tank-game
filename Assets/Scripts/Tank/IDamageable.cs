namespace BattleTank
{
    public interface IDamageable{
        public void Damage(TankName tankName, float damage);
        public TankName GetTankName();
    }
}
