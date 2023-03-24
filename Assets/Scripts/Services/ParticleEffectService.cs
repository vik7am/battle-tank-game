using System.Collections;
using UnityEngine;

namespace BattleTank
{
    public class ParticleEffectService : GenericSingleton<ParticleEffectService>
    {
        [SerializeField] private ParticleSystem tankExplosionEffact;
        [SerializeField] private float tankExplosionEffectDuration;

        public void ShowTankExplosionEffect(Vector3 spawnPosition){
            ParticleSystem effect = Instantiate(tankExplosionEffact, spawnPosition, Quaternion.identity);
            effect.Play();
            StartCoroutine(DestroyEffect(effect, tankExplosionEffectDuration));
        }

        IEnumerator DestroyEffect(ParticleSystem effect, float duration){
            yield return new WaitForSeconds(duration);
            Destroy(effect.gameObject);
        }
    }
}
