using UnityEngine;
using Aezakmi.Tweens;

namespace Aezakmi.Obstacles
{
    [RequireComponent(typeof(MoveByAmount))]
    public class BouncyPad : MonoBehaviour, IInteractable
    {
        private MoveByAmount _moveByAmount;

        private void Awake() => _moveByAmount = GetComponent<MoveByAmount>();
        public void Interact() => _moveByAmount.PlayTween();
    }
}
