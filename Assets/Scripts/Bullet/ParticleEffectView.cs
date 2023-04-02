using UnityEngine;

namespace BattleTank
{
    public class ParticleEffectView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem tankExplosionEffect;
        [SerializeField] private ParticleSystem bulletExplosionEffect;
        [SerializeField] private float tankExplosionEffectDuration;
        [SerializeField] private float bulletExplosionEffectDuration;

        public ParticleSystem getParticleEffect(ParticleEffectType particleEffectType){
            switch(particleEffectType){
                case ParticleEffectType.TANK_EXPLOSION : return tankExplosionEffect;
                case ParticleEffectType.BULLET_EXPLOSION : return bulletExplosionEffect;
            }
            return null;
        }

        public float getParticleEffectDuration(ParticleEffectType particleEffectType){
            switch(particleEffectType){
                case ParticleEffectType.TANK_EXPLOSION : return tankExplosionEffectDuration;
                case ParticleEffectType.BULLET_EXPLOSION : return bulletExplosionEffectDuration;
            }
            return 0;
        }
    }
}
