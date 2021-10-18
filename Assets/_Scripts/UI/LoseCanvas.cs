using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aezakmi.UI
{
    public class LoseCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private float timer = 0.5f;
        private bool checkForTouch = false;
        private bool shouldTimerWork = false;

        private void Start()
        {
            EventManager.current.onPlayerDied += delegate { StartTimer(); };
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
