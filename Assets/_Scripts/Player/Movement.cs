using UnityEngine;

namespace Aezakmi.Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TouchInput))]
    public class Movement : MonoBehaviour
    {
        public float ForwardSpeed;
        public float SideAcceleration;
        public float MaxSideSpeed;
        public float JumpStrength;

        private Rigidbody _rigidBody;
        private TouchInput _touchInput;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _touchInput = GetComponent<TouchInput>();
        }

        private void Update()
        {
            if (_touchInput.IsTouching) SetSideAcceleration();
            if(Input.GetKeyDown(KeyCode.Space)) Jump();
        }

        private void FixedUpdate() => SetSpeedForward();

        public void Jump() => _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, JumpStrength, _rigidBody.velocity.z);
        private void SetSpeedForward() => _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, _rigidBody.velocity.y, ForwardSpeed);
        private void SetSideAcceleration()
        {
            if(_rigidBody.velocity.x <= MaxSideSpeed)
                _rigidBody.AddForce(Vector3.right * _touchInput.TouchPosition.x * SideAcceleration * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
