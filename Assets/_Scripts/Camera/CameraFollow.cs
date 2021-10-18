using UnityEngine;

namespace Aezakmi.CameraControls
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        public float OffsetZ;
        public float FollowSpeed;

        private Vector3 _targetPosition;

        private void LateUpdate() => FollowTarget();

        private void FollowTarget()
        {
            if(_targetTransform != null)
                _targetPosition = Vector3.Lerp(transform.position, _targetTransform.position + Vector3.forward * OffsetZ, FollowSpeed * Time.deltaTime);

            transform.position = new Vector3(transform.position.x, transform.position.y, _targetPosition.z);
        }
    }
}
