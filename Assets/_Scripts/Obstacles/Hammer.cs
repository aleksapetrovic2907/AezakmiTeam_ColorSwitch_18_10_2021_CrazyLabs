using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Obstacles
{
    public class Hammer : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotateAmount;
        [SerializeField] private float _timeWaitWhenDown;
        [SerializeField] private float _startDelay;

        [Header("Hammer going down")]
        [SerializeField] private float _downDuration;
        [SerializeField] private Ease _downEase;


        [Header("Hammer going back up")]
        [SerializeField] private float _upDuration;
        [SerializeField] private Ease _upEase;

        private Sequence _sequence;

        private void Awake()
        {
            _sequence = DOTween.Sequence();
            _sequence
                .Append(transform.DORotate(_rotateAmount, _downDuration, RotateMode.Fast).SetEase(_downEase))
                .AppendInterval(_timeWaitWhenDown)
                .Append(transform.DORotate(transform.eulerAngles, _upDuration, RotateMode.Fast).SetEase(_upEase))
                .SetLoops(-1)
                .SetDelay(_startDelay)
                .Play();
        }

        private void OnDestroy() => _sequence.Kill();
    }
}
