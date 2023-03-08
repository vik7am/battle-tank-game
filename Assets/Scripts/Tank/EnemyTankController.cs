using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController : TankController
    {
        private EnemyTankAI enemyTankAI;
        public EnemyTankController(TankModel tankModel, TankView tankView, Vector3 position) : base(tankModel, tankView){
            Initialize(position);
        }

        private void Initialize(Vector3 position){
            tankView = GameObject.Instantiate<TankView>(tankView, position, Quaternion.identity);
            tankView.SetTankController(this);
            enemyTankAI = new EnemyTankAI();
            TankService.Instance.SetEnemyTankForUpdate(enemyTankAI);
        }

        public override Vector3 GetMovementVelocity(){
            return enemyTankAI.GetEnemyVI() * tankModel.movementSpeed * tankView.transform.forward;
        }

        public override float GetRotationAngle(){
            return enemyTankAI.GetEnemyHI() * tankModel.rotationSpeed;
        }

        public override void FireBullet() {}
    }
}

