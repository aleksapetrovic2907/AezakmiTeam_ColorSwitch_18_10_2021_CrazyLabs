using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aezakmi.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class SliderValueChanger : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private string _prefix;

        private TextMeshProUGUI _textMeshProUGUI;

        private void Awake() => _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        public void UpdateText() => _textMeshProUGUI.text = $"{_prefix} ({_slider.value.ToString("0.00")})";
    }
}
