using UnityEngine;
using System.Collections.Generic;

namespace BattleTank
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private Rigidbody rb;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;

        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        private void UpdateTankColor(){
            Material material = tankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }

        private void Update(){
            if(tankController.GetRotationAngle() != 0){
                transform.Rotate(transform.up, tankController.GetRotationAngle() * Time.deltaTime);
            }
        }

        private void FixedUpdate() {
            rb.velocity = tankController.GetMovementVelocity();
        }
        
        public void SetTankController(TankController tankController){
            this.tankController = tankController;
            UpdateTankColor();
        }

        public void TakeDamage(float damage){
            tankController.ReduceHealth(damage);
        }

        public void DestroyTank(){
            Destroy(gameObject);
        }

    }
}
