using UnityEngine;
using System.Collections.Generic;
/*
namespace BattleTank
{
    public abstract class TankView : MonoBehaviour
    {
        protected Rigidbody rb;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;

        private void Awake(){
            rb = GetComponent<Rigidbody>();
        }

        protected void UpdateTankColor(){
            Material material = tankController.GetMaterial();
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
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
*/