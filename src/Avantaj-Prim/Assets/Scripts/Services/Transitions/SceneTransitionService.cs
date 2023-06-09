using DG.Tweening;
using UnityEngine;

namespace Services.Transitions
{
    public class SceneTransitionService : MonoBehaviour, ISceneTransitionService
    {
        [SerializeField] private float _fadeTime = 3f;
        private CanvasGroup _canvasGroup;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeIn()
        {
            _canvasGroup.alpha = 1;
            gameObject.SetActive(true);
        }

        public void FadeOut()
        {
            _canvasGroup
                .DOFade(0, _fadeTime)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}