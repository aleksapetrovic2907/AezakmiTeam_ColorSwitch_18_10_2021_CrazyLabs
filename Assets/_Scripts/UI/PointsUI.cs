using UnityEngine;
using TMPro;
using Aezakmi.Tweens;

namespace Aezakmi.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(Scale))]
    public class PointsUI : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;
        private Scale _scale;

        private void Awake()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            _scale = GetComponent<Scale>();
        }

        private void Start()
        {
            EventManager.current.onPointPickedUp += UpdatePoints;
        }

        private void UpdatePoints()
        {
            _textMeshProUGUI.text = GameManager.current.Points.ToString();
            _scale.PlayTween();
        }
    }
}
