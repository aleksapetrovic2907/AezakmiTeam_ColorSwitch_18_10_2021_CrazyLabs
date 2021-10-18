using UnityEngine;
using Aezakmi.Colors;
using Aezakmi.Obstacles;
using System;

namespace Aezakmi.Player
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(ColorController))]
    public class CollisionManager : MonoBehaviour
    {
        public bool AffectedByColors = true;

        private Movement _movement;
        private ColorController _colorController;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _colorController = GetComponent<ColorController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            CheckIfSameColor(collision.gameObject);
            CheckIfJumpOffable(collision.gameObject);

            if(collision.gameObject.GetComponent<IInteractable>() != null) collision.gameObject.GetComponent<IInteractable>().Interact();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckIfPickupable(other.gameObject);
            CheckIfInstantDeath(other.gameObject);
        }


        private void CheckIfSameColor(GameObject obj)
        {
            if (obj.layer == LayerMask.NameToLayer("ColoredObstacle") && AffectedByColors)
            {
                if(_colorController.ObjectColor != obj.GetComponent<ColorController>().ObjectColor)
                {
                    EventManager.current.PlayerDied(transform.position.z);
                    Destroy(this.gameObject);
                }
            }
        }
        
        private void CheckIfInstantDeath(GameObject obj)
        {
            if (obj.layer == LayerMask.NameToLayer("InstantDeath"))
            {
                EventManager.current.PlayerDied(transform.position.z);
                Destroy(this.gameObject);
            }
        }

        private void CheckIfPickupable(GameObject obj)
        {
            if (obj.layer == LayerMask.NameToLayer("Pickupable"))
            {
                if(obj.CompareTag("ColorChanger"))
                {
                    _colorController.SetRandomColor();
                }

                Destroy(obj);
            }
        }

        private void CheckIfJumpOffable(GameObject obj)
        {
            if (obj.GetComponent<JumpOffable>() != null)
            {
                _movement.Jump(obj.GetComponent<JumpOffable>().JumpStrength);
            }
        }
    }
}
