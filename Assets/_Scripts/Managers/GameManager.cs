using System;
using UnityEngine;

namespace Aezakmi
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager current;

        private void Awake()
        {
            if(current != this) current = this;
        }

        private void Start()
        {
            EventManager.current.onPointPickedUp += AddPoint;
            EventManager.current.onPlayerDied += CheckIfHighscore;
        }

        private void CheckIfHighscore(float positionZ)
        {
            if(positionZ > GameData.highscorePositionZ) GameData.highscorePositionZ = positionZ;
        }

        public int Points;

        private void AddPoint() => Points++;
    }

    public static class GameData
    {
        public static float highscorePositionZ = -27.13f;
    }
}
