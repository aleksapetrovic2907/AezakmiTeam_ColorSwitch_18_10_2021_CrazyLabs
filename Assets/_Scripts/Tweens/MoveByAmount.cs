using UnityEngine;
using DG.Tweening;

namespace Aezakmi.Tweens
{
    public class MoveByAmount : BaseTween
    {
        [SerializeField] private Vector3 _amount;

        protected override void SetTweener()
        {
            if (_componentUsed == ComponentUsed.RigidBody)
            {
                _tweener = _rigidBody
                    .DOMove(transform.position + _amount, _loopDuration)
                    .SetLoops(_loopCount, _loopType)
                    .SetEase(_loopEase)
                    .SetUpdate(UpdateType.Fixed);
            }
            else
            {
                _tweener = transform
                    .DOMove(transform.position + _amount, _loopDuration)
                    .SetLoops(_loopCount, _loopType)
                    .SetEase(_loopEase);
            }
        }
    }
}
