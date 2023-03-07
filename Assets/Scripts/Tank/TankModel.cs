namespace BattleTank
{
    public class TankModel
    {
        public TankType tankType;
        public float health;
        public float damage;
        public float movementSpeed;
        public float rotationSpeed;
        public TankView tankView;

        public TankModel(TankSO tankSO){
            tankType = tankSO.tankType;
            health = tankSO.health;
            damage = tankSO.damage;
            movementSpeed = tankSO.movementSpeed;
            rotationSpeed = tankSO.rotationSpeed;
            tankView = tankSO.tankView;
        }
    }
}
