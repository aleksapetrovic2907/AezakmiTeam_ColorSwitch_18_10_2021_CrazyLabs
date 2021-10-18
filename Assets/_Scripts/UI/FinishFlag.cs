using UnityEngine;

namespace Aezakmi
{
    [RequireComponent(typeof(Collider))]
    public class FinishFlag : MonoBehaviour
    {
        private Collider _collider;
        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Destroy(this._collider);
                EventManager.current.GameFinished();
            }
        }
    }
}
