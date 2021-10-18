using UnityEngine;

namespace Aezakmi.Colors
{
    [RequireComponent(typeof(Renderer))]
    [ExecuteInEditMode]
    public class ColorController : MonoBehaviour
    {
        public bool RandomColorOnAwake = false;
        public ObjectColor ObjectColor;
        public ColorData ColorData;

        private Renderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();

            if (RandomColorOnAwake) SetRandomColor();
            else SetColor(ObjectColor); // Used for executing while in editor
        }

        public void SetRandomColor() => SetColor((ObjectColor)Random.Range(0, 4));

        public void SetColor(ObjectColor color)
        {
            ObjectColor = color;
            _renderer.material = ColorData.colors[(int)ObjectColor];
        }
    }
}
