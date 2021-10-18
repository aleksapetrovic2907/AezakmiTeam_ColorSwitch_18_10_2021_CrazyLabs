using UnityEngine;

namespace Aezakmi.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TouchInput))]
    public class Movement : MonoBehaviour
    {
        public float ForwardSpeed;
        public float SideLerpSpeed;

        private Vector3 _targetPosition;
        private bool canMove = true;

        private Rigidbody _rigidBody;
        private TouchInput _touchInput;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _touchInput = GetComponent<TouchInput>();
        }

        private void Start()
        {
            EventManager.current.onGameFinished += delegate { canMove = false; };
        }

        private void FixedUpdate()
        {
            SetSpeedForward();
            SetSideAcceleration();
            SlowDown();
        }

        public void Jump(float JumpStrength) => _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, JumpStrength, _rigidBody.velocity.z);

        private void SetSpeedForward()
        {
            if (canMove)
                _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _rigidBody.velocity.y, ForwardSpeed);
        }

        private void SetSideAcceleration()
        {
            if (_touchInput.IsTouching && canMove)
            {
                _targetPosition = Vector3.Lerp(transform.position, Vector3.right * (_touchInput.TouchPosition.x * 5), SideLerpSpeed * Time.fixedDeltaTime);
                transform.position = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
            }
        }

        private void SlowDown()
        {
            if (!canMove)
                _rigidBody.velocity = Vector3.Lerp(_rigidBody.velocity, Vector3.zero, Time.fixedDeltaTime);
        }
    }
}
