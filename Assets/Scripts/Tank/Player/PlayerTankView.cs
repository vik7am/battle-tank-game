using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class PlayerTankView : MonoBehaviour
    {
        private PlayerTankController playerTankController;
        private Rigidbody rb;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;
        
        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        private void UpdateTankColor(){
            Material material = playerTankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }
        
        public void SetTankController(PlayerTankController playerTankController){
            this.playerTankController = playerTankController;
            UpdateTankColor();
        }

        public void TakeDamage(float damage){
            playerTankController.ReduceHealth(damage);
        }

        public void DestroyTank(){
            Destroy(gameObject);
        }

        private void Update(){
            if(playerTankController.GetRotationAngle() != 0){
                transform.Rotate(transform.up, playerTankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate() {
            rb.velocity = playerTankController.GetMovementVelocity();
        }
    }
}
