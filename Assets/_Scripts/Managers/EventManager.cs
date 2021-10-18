using System;
using UnityEngine;

namespace Aezakmi
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager current;

        private void Awake()
        {
            if (current != this) current = this;
        }

        public event Action onPointPickedUp;
        public void PointPickedUp()
        {
            if (onPointPickedUp != null) onPointPickedUp();
        }

        public event Action<float> onPlayerDied;
        public void PlayerDied(float zPosition)
        {
            if(onPlayerDied != null) onPlayerDied(zPosition);
        }

        public event Action onGameFinished;
        public void GameFinished()
        {
            if(onGameFinished != null) onGameFinished();
        }
    }
}
