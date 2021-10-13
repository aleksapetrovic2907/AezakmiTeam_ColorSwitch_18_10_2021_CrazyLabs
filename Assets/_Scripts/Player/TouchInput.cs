using UnityEngine;

namespace Aezakmi.Player
{
    public class TouchInput : MonoBehaviour
    {
        private const float OFFSET = .5f;

        public Vector3 TouchPosition { get; private set; }
        public bool IsTouching { get { return Input.touchCount > 0; } }

        private Touch _touch;

        private void Update()
        {
            if (IsTouching)
            {
                _touch = Input.GetTouch(0);

                /* The reason offset and doubling is used is so the left side of the screen is -1.0f, the center 0.0f, and the right side 1.0f */
                TouchPosition = (Camera.main.ScreenToViewportPoint(_touch.position) - (Vector3.one * OFFSET)) * 2 ;
            }
        }
    }
}
