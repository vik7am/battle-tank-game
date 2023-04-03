using System.Collections;
using UnityEngine;

namespace BattleTank
{
    public class ParticleEffectService : GenericMonoSingleton<ParticleEffectService>
    {    
        public void ShowParticleEffect(Vector3 spawnPosition, ParticleEffectType particleEffectType){
            ParticleEffectView effectView = ObjectPoolService.Instance.particlePool.GetItem();
            ParticleSystem effect = effectView.getParticleEffect(particleEffectType);
            float duration = effectView.getParticleEffectDuration(particleEffectType);
            effectView.transform.position = spawnPosition;
            effectView.gameObject.SetActive(true);
            effect.Play();
            StartCoroutine(DestroyEffect(effectView, duration));
        }

        IEnumerator DestroyEffect(ParticleEffectView effectView, float duration){
            yield return new WaitForSeconds(duration);
            ObjectPoolService.Instance.particlePool.ReturnItem(effectView);
        }
    }
}
