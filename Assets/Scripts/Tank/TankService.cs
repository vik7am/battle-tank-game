using UnityEngine;
using System.Collections.Generic;

namespace BattleTank
{
    public class TankService : GenericSingleton<TankService>
    {
        private TankModel tankModel;
        private TankController tankController;
        private List<EnemyTankAI> enemyTankAIList;
        [SerializeField] private GameObject cam;
        [SerializeField] private FixedJoystick joystick;
        [SerializeField] private TankListSO tankListSO;
        [SerializeField] private TankView tankView;

        private void Start(){
            SpawnPlayerTank();
            enemyTankAIList = new List<EnemyTankAI>();
            SpawnEnemyTanks();
        }

        private void Update() {
            CheckPlayerInput();
            UpdateEnemtyTankAI();
        }

        private void CheckPlayerInput(){
            if(Input.GetKeyDown(KeyCode.Space))
                tankController.FireBullet();
        }

        private void UpdateEnemtyTankAI(){
            for(int i=0; i<enemyTankAIList.Count; i++)
                enemyTankAIList[i].UpdateDuration(Time.deltaTime);
        }

        private void SpawnPlayerTank(){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            tankController = new PlayerTankController(tankModel, tankView);
        }

        private void SpawnEnemyTanks(){
            for(int i=1; i<=3; i++){
                SpawnEnemyTank(new Vector3(-i*10, 0, 0));
            }
        }

        private void SpawnEnemyTank(Vector3 position){
            int tankNo = Random.Range(0, tankListSO.tankSO.Length);
            tankModel = new TankModel(tankListSO.tankSO[tankNo]);
            new EnemyTankController(tankModel, tankView, position);
        }

        public void SetCameraToFollowPlayer(Transform player){
            cam.transform.SetParent(player);
        }

        public void SetEnemyTankForUpdate(EnemyTankAI enemyTankAI){
            enemyTankAIList.Add(enemyTankAI);
        }

        public float GetPlayerHI(){
            if(Mathf.Abs(joystick.Horizontal) > Mathf.Epsilon)
                return joystick.Horizontal;
            return Input.GetAxisRaw("HorizontalUI");
        }

        public float GetPlayerVI(){
            if(Mathf.Abs(joystick.Vertical) > Mathf.Epsilon)
                return joystick.Vertical;
            return Input.GetAxisRaw("VerticalUI");
        }
    }
}
