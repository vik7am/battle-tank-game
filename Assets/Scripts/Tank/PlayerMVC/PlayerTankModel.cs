using UnityEngine;

namespace BattleTank
{
    public class PlayerTankModel
    {
        public TankType tankType {get;}
        public BulletType bulletType {get;}
        public float health {get;}
        public float movementSpeed {get;}
        public float rotationSpeed {get;}
        public Material material {get;}
        public int playerLives {get;}

        public PlayerTankModel(PlayerTankSO playerTankSO){
            tankType = playerTankSO.tankType;
            bulletType = playerTankSO.bulletType;
            health = playerTankSO.health;
            movementSpeed = playerTankSO.movementSpeed;
            rotationSpeed = playerTankSO.rotationSpeed;
            material = playerTankSO.material;
            playerLives = playerTankSO.tankLives;
        }
    }
}
