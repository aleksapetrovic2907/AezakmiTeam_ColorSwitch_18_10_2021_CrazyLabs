using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public enum ComponentUsed
    {
        RigidBody,
        Transform
    }

    public abstract class BaseTween : MonoBehaviour
    {
        [SerializeField] protected int _loopCount;
        [SerializeField] protected float _loopDuration;
        [SerializeField] protected LoopType _loopType;
        [SerializeField] protected Ease _loopEase;
        [SerializeField] protected ComponentUsed _componentUsed;

        [SerializeField] private bool _playOnAwake;

        protected Tweener _tweener;
        protected Rigidbody _rigidBody;

        private void Awake()
        {
            if(_componentUsed == ComponentUsed.RigidBody) _rigidBody = GetComponent<Rigidbody>();

            SetTweener();

            if (_playOnAwake) PlayTween();
        }

        public void PlayTween() => _tweener.Play();

        protected abstract void SetTweener();
        private void OnDestroy() => _tweener.Kill();
    }
}
