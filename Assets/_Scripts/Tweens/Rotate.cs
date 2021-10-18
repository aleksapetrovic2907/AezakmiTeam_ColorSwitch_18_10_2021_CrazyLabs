using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class Rotate : BaseTween
    {
        [SerializeField] private Vector3 _rotationEnd;

        protected override void SetTweener()
        {
            _rigidBody = GetComponent<Rigidbody>();

            if (_componentUsed == ComponentUsed.RigidBody)
            {
                _tweener = transform.
                DORotate(_rotationEnd, _loopDuration)
                .SetLoops(_loopCount, _loopType)
                .SetEase(_loopEase)
                .SetUpdate(UpdateType.Fixed);
            }
            else
            {
                _tweener = transform.
                    DORotate(_rotationEnd, _loopDuration)
                    .SetLoops(_loopCount, _loopType)
                    .SetEase(_loopEase);
            }
        }
    }
}
