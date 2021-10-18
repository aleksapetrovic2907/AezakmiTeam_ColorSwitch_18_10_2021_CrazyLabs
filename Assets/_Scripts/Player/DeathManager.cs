using UnityEngine;
using Aezakmi.Colors;
namespace Aezakmi.Player
{
    public class DeathManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private ColorData _colorData;

        private void OnDestroy()
        {
            var particles = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            particles.startColor = _colorData.colorsHEX[(int)GetComponent<ColorController>().ObjectColor];
        }
    }
}
