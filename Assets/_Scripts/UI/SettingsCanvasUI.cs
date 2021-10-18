using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aezakmi.UI
{
    public class SettingsCanvasUI : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;

        [Header("Bird Camera")]
        [SerializeField] private GameObject _birdSettings;
        [SerializeField] private TMP_InputField[] _birdPosition = new TMP_InputField[2];
        [SerializeField] private TMP_InputField[] _birdRotation = new TMP_InputField[3];
        [SerializeField] private Slider _birdFOV;
        [SerializeField] private TextMeshProUGUI _birdFOV_Text;
        [SerializeField] private Slider _birdOffsetZ;
        [SerializeField] private TextMeshProUGUI _birdOffsetZ_Text;
        [SerializeField] private TMP_InputField _birdFollowSpeed;

        [Header("Third Person Camera")]
        [SerializeField] private GameObject _thirdPersonSettings;
        [SerializeField] private TMP_InputField[] _thirdPersonPosition = new TMP_InputField[2];
        [SerializeField] private TMP_InputField[] _thirdPersonRotation = new TMP_InputField[3];
        [SerializeField] private Slider _thirdPersonFOV;
        [SerializeField] private TextMeshProUGUI _thirdPersonFOV_Text;
        [SerializeField] private Slider _thirdPersonOffsetZ;
        [SerializeField] private TextMeshProUGUI _thirdPersonOffsetZ_Text;
        [SerializeField] private TMP_InputField _thirdPersonFollowSpeed;

        [Header("Obstacles")]
        [SerializeField] private Toggle _airSpikes;
        [SerializeField] private Toggle _rotatingSpikes;
        [SerializeField] private Toggle _colorChangers;
        [SerializeField] private Toggle _hammers;

        [Header("Player")]
        [SerializeField] private Toggle _affectedByColors;
        [SerializeField] private TMP_InputField _forwardSpeed;
        [SerializeField] private TMP_InputField _sideLerpSpeed;

        public void Pause()
        {
            _parent.SetActive(true);
            LoadSettings();
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
        }

        public void Unpause()
        {
            _parent.SetActive(false);
            Time.timeScale = 1;
        }
        
        public void SetActiveBird()
        {
            _thirdPersonSettings.SetActive(false);
            _birdSettings.SetActive(true);
        }

        public void SetActiveThirdPerson()
        {
            _birdSettings.SetActive(false);
            _thirdPersonSettings.SetActive(true);
        }

        private void LoadSettings()
        {
            // Camera
            if (Settings.ActiveCamera == ActiveCamera.Bird) SetActiveBird();
            else SetActiveThirdPerson();

            LoadBirdSettings();
            LoadThirdPersonSettings();

            // Obstacles
            _airSpikes.isOn = Settings.AirSpikes;
            _rotatingSpikes.isOn = Settings.RotatingSpikes;
            _colorChangers.isOn = Settings.ColorChangers;
            _hammers.isOn = Settings.Hammers;

            // Player
            _affectedByColors.isOn = Settings.AffectedByColors;
            _forwardSpeed.text = Settings.ForwardSpeed.ToString();
            _sideLerpSpeed.text = Settings.SideLerpSpeed.ToString();
        }

        private void LoadBirdSettings()
        {
            _birdPosition[0].text = Settings.BirdSettings.Position.x.ToString();
            _birdPosition[1].text = Settings.BirdSettings.Position.y.ToString();

            _birdRotation[0].text = Settings.BirdSettings.Rotation.x.ToString();
            _birdRotation[1].text = Settings.BirdSettings.Rotation.y.ToString();
            _birdRotation[2].text = Settings.BirdSettings.Rotation.z.ToString();

            _birdFOV.value = (int)Settings.BirdSettings.FOV;
            _birdFOV_Text.text = $"FOV ({((int)Settings.BirdSettings.FOV).ToString()})";

            _birdOffsetZ.value = Settings.BirdSettings.OffsetZ;
            _birdOffsetZ_Text.text = $"Offset Z ({(Settings.BirdSettings.OffsetZ).ToString("0.00")})";

            _birdFollowSpeed.text = Settings.BirdSettings.FollowSpeed.ToString();
        }

        private void LoadThirdPersonSettings()
        {
            _thirdPersonPosition[0].text = Settings.ThirdPersonSettings.Position.x.ToString();
            _thirdPersonPosition[1].text = Settings.ThirdPersonSettings.Position.y.ToString();

            _thirdPersonRotation[0].text = Settings.ThirdPersonSettings.Rotation.x.ToString();
            _thirdPersonRotation[1].text = Settings.ThirdPersonSettings.Rotation.y.ToString();
            _thirdPersonRotation[2].text = Settings.ThirdPersonSettings.Rotation.z.ToString();

            _thirdPersonFOV.value = (int)Settings.ThirdPersonSettings.FOV;
            _thirdPersonFOV_Text.text = $"FOV ({((int)Settings.ThirdPersonSettings.FOV).ToString()})";

            _thirdPersonOffsetZ.value = Settings.ThirdPersonSettings.OffsetZ;
            _thirdPersonOffsetZ_Text.text = $"Offset Z ({(Settings.ThirdPersonSettings.OffsetZ).ToString("0.00")})";

            _thirdPersonFollowSpeed.text = Settings.ThirdPersonSettings.FollowSpeed.ToString();
        }
    }
}
