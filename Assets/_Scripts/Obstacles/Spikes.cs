using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Obstacles
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField] private float _moveAmountY;
        [SerializeField] private float _timeWaitWhenDown;
        [SerializeField] private float _startDelay;

        [Header("Spikes going down")]
        [SerializeField] private float _downDuration;
        [SerializeField] private Ease _downEase;


        [Header("Spikes going back up")]
        [SerializeField] private float _upDuration;
        [SerializeField] private Ease _upEase;

        private Rigidbody _rigidBody;
        private Sequence _sequence;
        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();

            _sequence = DOTween.Sequence();
            _sequence
                .Append(_rigidBody.DOMoveY(transform.position.y + _moveAmountY, _downDuration).SetEase(_downEase))
                .AppendInterval(_timeWaitWhenDown)
                .Append(_rigidBody.DOMoveY(transform.position.y, _upDuration).SetEase(_upEase))
                .SetLoops(-1)
                .SetDelay(_startDelay)
                .Play();
        }

        private void OnDestroy() => _sequence.Kill();
    }
}
