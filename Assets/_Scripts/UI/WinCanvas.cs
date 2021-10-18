using UnityEngine;

namespace Aezakmi.UI
{
    public class WinCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private float timer = 0.5f;
        private bool checkForTouch = false;
        private bool shouldTimerWork = false;

        private void Start()
        {
            EventManager.current.onGameFinished += StartTimer;
        }

        private void Update()
        {
            if (shouldTimerWork)
            {
                if (timer >= 0f) timer -= Time.deltaTime;
                else
                {
                    shouldTimerWork = false;
                    checkForTouch = true;
                    DisplayWinScreen();
                }
            }

            if (Input.touchCount > 0 && checkForTouch)
                scenes.current.ReloadScene();
        }

        private void DisplayWinScreen() => _parent.SetActive(true);
        private void StartTimer() => shouldTimerWork = true;
    }
}
