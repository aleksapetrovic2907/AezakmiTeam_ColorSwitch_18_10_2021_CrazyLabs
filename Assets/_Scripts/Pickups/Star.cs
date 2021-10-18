using UnityEngine;

namespace Aezakmi.Pickups
{
    public class Star : MonoBehaviour
    {
        private void OnDestroy() => EventManager.current.PointPickedUp();
    }
}
