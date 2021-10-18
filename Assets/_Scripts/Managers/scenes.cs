using UnityEngine;
using UnityEngine.SceneManagement;

namespace Aezakmi
{
    public class scenes : MonoBehaviour
    {
        public static scenes current;
        private void Awake()
        {
            if(current != this) current = this;
        }

        public void ReloadScene() => SceneManager.LoadScene(0);
    }
}
