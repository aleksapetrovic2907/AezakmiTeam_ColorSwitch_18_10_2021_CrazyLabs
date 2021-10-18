using UnityEngine;

namespace Aezakmi
{
    public class HighscoreUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _highscore;

        private void Awake()
        {
            if(GameData.highscorePositionZ > -27f)
            {
                _highscore.SetActive(true);
                _highscore.transform.position = new Vector3(_highscore.transform.position.x, _highscore.transform.position.y, GameData.highscorePositionZ);
            }
        }
    }
}
