using UnityEngine;

namespace Aezakmi.UI
{
    public class InstructionsUI : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 0f;
        }

        private void Update()
        {
            if(Input.touchCount > 0)
            {
                Time.timeScale = 1;
                Destroy(gameObject);
            }
        }
    }
}
