using DG.Tweening;
using UnityEngine;

namespace Card
{
    public class CardEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;
        [SerializeField] private Transform cardTransform;
        private Tween tween;
        
        public void Shake()
        {
            if(tween.IsActive() && tween.IsPlaying())
                return;
            tween =  cardTransform.DOShakePosition(1f, new Vector3(0.5f, 0, 0));
        }

        public void Bounce()
        {
            //tween.Kill();
            tween = cardTransform
                .DOScale(3, 0.5f)
                .SetEase(Ease.InOutSine)
                .OnComplete(() =>
                {
                    cardTransform
                        .DOScale(2f, 0.5f)
                        .SetEase(Ease.OutBounce);
                });
        }

        public void PlayParticles()
        {
            particle.Play();
        }

        private void OnDestroy()
        {
            tween.Kill();
        }
    }
}