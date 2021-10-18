using UnityEngine;

namespace Aezakmi.Colors
{
    public enum ObjectColor
    {
        Color1,
        Color2,
        Color3,
        Color4
    }

    [CreateAssetMenu(fileName = "Colors", menuName = "ScriptableObjects/Colors")]
    public class ColorData : ScriptableObject
    {
        public Material[] colors;
        public Color32[] colorsHEX;
    }
}
