using UnityEngine;
using DG.Tweening;

namespace Aezakmi
{
    public class HandUI : MonoBehaviour
    {
        [SerializeField] private float _loopDuration;

        private RectTransform _rectTransform;
        private Sequence _sequence;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _sequence = DOTween.Sequence();
            
            _sequence.Append(
                _rectTransform
                    .DOMoveX(Screen.width, _loopDuration / 2)
                    .SetEase(Ease.Linear)
            ).Append(
                _rectTransform
                    .DOMoveX(0, _loopDuration)
                    .SetEase(Ease.Linear)
                    .SetLoops(int.MaxValue, LoopType.Yoyo)
            ).SetUpdate(true).Play();
        }
    }
}
