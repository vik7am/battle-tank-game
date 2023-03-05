namespace BattleTank
{
    public struct TankModel
    {
        public float movementSpeed;
        public float rotationSpeed;

        public TankModel(float movementSpeed, float rotationSpeed){
            this.movementSpeed = movementSpeed;
            this.rotationSpeed = rotationSpeed;
        }
    }
}
