using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class PlayerTankView : MonoBehaviour, IDamageable
    {
        private PlayerTankController playerTankController;
        public GameObject bulletSpawPoint;
        public List<MeshRenderer> tankBody;

        public void SetTankMaterial(Material material){
            for(int i=0; i<tankBody.Count; i++)
                tankBody[i].material = material;
        }
        
        public void SetTankController(PlayerTankController playerTankController){
            this.playerTankController = playerTankController;
        }

        public void Damage(TankName shooter, float damage){
            playerTankController.TakeDmage(shooter, damage);
        }

        public void ShowEffectAndDestroy(){
            Destroy(gameObject, 1.0f);
            ParticleEffectService.Instance.ShowParticleEffect(transform.position, ParticleEffectType.TANK_EXPLOSION);
        }

        public TankName GetTankName(){
            return TankName.PLAYER_TANK;
        }

        public Vector3 GetTankPosition(){
            return transform.position;
        }
    }
}
