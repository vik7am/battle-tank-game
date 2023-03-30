using System.Collections;
using UnityEngine;

namespace BattleTank
{
    public class ParticleEffectService : GenericMonoSingleton<ParticleEffectService>
    {
        [SerializeField] private ParticleSystem tankExplosionEffact;
        [SerializeField] private float tankExplosionEffectDuration;

        public void ShowTankExplosionEffect(Vector3 spawnPosition){
            ParticleSystem effect = ObjectPoolService.Instance.particlePool.GetItem();
            effect.transform.position = spawnPosition;
            effect.gameObject.SetActive(true);
            effect.Play();
            StartCoroutine(DestroyEffect(effect, tankExplosionEffectDuration));
        }

        IEnumerator DestroyEffect(ParticleSystem effect, float duration){
            yield return new WaitForSeconds(duration);
            ObjectPoolService.Instance.particlePool.ReturnItem(effect);
        }
    }
}
