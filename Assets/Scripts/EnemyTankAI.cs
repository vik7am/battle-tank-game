using UnityEngine;
namespace BattleTank{
    public class EnemyTankAI
    {
        private TankMovement tankMovement;
        private TankRotation tankRotation;
        private float currentDuration;
        private float minDuration = 2;
        private float maxDuration = 5;

        public EnemyTankAI(){
            RandomTankAction();
        }

        public void UpdateDuration(float deltaTime){
            currentDuration -= deltaTime;
            if(currentDuration<=0)
                RandomTankAction();
        }

        private void RandomTankAction(){
            tankMovement = (TankMovement)Random.Range(0, 2);
            tankRotation = (TankRotation)Random.Range(0, 3);
            currentDuration = Random.Range(minDuration, maxDuration);
        }

        public float GetEnemyVI(){
            if(tankMovement == TankMovement.FORWARD)
                return 1;
            return 0;
        }

        public float GetEnemyHI(){
            if(tankRotation == TankRotation.LEFT)
                return -1;
            if(tankRotation == TankRotation.RIGHT)
                return 1;
            return 0;
        }
    }
}

