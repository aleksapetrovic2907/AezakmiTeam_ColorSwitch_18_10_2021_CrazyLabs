using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Aezakmi.Player;
using Aezakmi.CameraControls;

namespace Aezakmi
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager current;

        private void Awake()
        {
            if (current != this) current = this;

            _bird = _cameraBird.GetComponent<Camera>();
            _thirdPerson = _cameraThirdPerson.GetComponent<Camera>();

            SetDefaultSettings();
        }

        private void SetDefaultSettings()
        {
            if (Settings.ActiveCamera == ActiveCamera.Bird) SetActiveBird();
            else SetActiveThirdPerson();

            _airSpikes.SetActive(Settings.AirSpikes);
            _rotatingSpikes.SetActive(Settings.RotatingSpikes);
            _colorChangers.SetActive(Settings.ColorChangers);

            _playerColManager.AffectedByColors = Settings.AffectedByColors;
            _playerMovement.ForwardSpeed = Settings.ForwardSpeed;
            _playerMovement.SideLerpSpeed = Settings.SideLerpSpeed;

            _bird.transform.position = new Vector3(Settings.BirdSettings.Position.x, Settings.BirdSettings.Position.y, _bird.transform.position.z);
            _bird.transform.eulerAngles = new Vector3(Settings.BirdSettings.Rotation.x, Settings.BirdSettings.Rotation.y, Settings.BirdSettings.Rotation.z);
            _bird.fieldOfView = Settings.BirdSettings.FOV;
            _bird.GetComponent<CameraFollow>().OffsetZ = Settings.BirdSettings.OffsetZ;
            _bird.GetComponent<CameraFollow>().FollowSpeed = Settings.BirdSettings.FollowSpeed;

            _thirdPerson.transform.position = new Vector3(Settings.ThirdPersonSettings.Position.x, Settings.ThirdPersonSettings.Position.y, _thirdPerson.transform.position.z);
            _thirdPerson.transform.eulerAngles = new Vector3(Settings.ThirdPersonSettings.Rotation.x, Settings.ThirdPersonSettings.Rotation.y, Settings.ThirdPersonSettings.Rotation.z);
            _thirdPerson.fieldOfView = Settings.ThirdPersonSettings.FOV;
            _thirdPerson.GetComponent<CameraFollow>().OffsetZ = Settings.ThirdPersonSettings.OffsetZ;
            _thirdPerson.GetComponent<CameraFollow>().FollowSpeed = Settings.ThirdPersonSettings.FollowSpeed;
        }

        #region CAMERA
        [SerializeField] private GameObject _cameraBird;
        [SerializeField] private GameObject _cameraThirdPerson;

        [SerializeField] private TMP_InputField[] _birdPosition = new TMP_InputField[2];
        [SerializeField] private TMP_InputField[] _birdRotation = new TMP_InputField[3];
        [SerializeField] private Slider _birdFOV;
        [SerializeField] private TextMeshProUGUI _birdFOVText;
        [SerializeField] private Slider _birdOffsetZ;
        [SerializeField] private TextMeshProUGUI _birdOffsetZText;
        [SerializeField] private TMP_InputField _birdFollowSpeed;

        [SerializeField] private TMP_InputField[] _thirdPersonPosition = new TMP_InputField[2];
        [SerializeField] private TMP_InputField[] _thirdPersonRotation = new TMP_InputField[3];
        [SerializeField] private Slider _thirdPersonFOV;
        [SerializeField] private TextMeshProUGUI _thirdPersonFOVText;
        [SerializeField] private Slider _thirdPersonOffsetZ;
        [SerializeField] private TextMeshProUGUI _thirdPersonOffsetZText;
        [SerializeField] private TMP_InputField _thirdPersonFollowSpeed;

        private Camera _bird;
        private Camera _thirdPerson;

        public void SetActiveBird()
        {
            _cameraThirdPerson.SetActive(false);
            _cameraBird.SetActive(true);
            Settings.ActiveCamera = ActiveCamera.Bird;
        }

        public void SetActiveThirdPerson()
        {
            _cameraBird.SetActive(false);
            _cameraThirdPerson.SetActive(true);
            Settings.ActiveCamera = ActiveCamera.ThirdPerson;
        }

        #region BIRD
        public void UpdateBirdPositionX()
        {
            Settings.BirdSettings.Position.x = float.Parse(_birdPosition[0].text.Trim());
            _bird.transform.position = new Vector3(Settings.BirdSettings.Position.x, _bird.transform.position.y, _bird.transform.position.z);
        }

        public void UpdateBirdPositionY()
        {
            Settings.BirdSettings.Position.y = float.Parse(_birdPosition[1].text.Trim());
            _bird.transform.position = new Vector3(_bird.transform.position.x, Settings.BirdSettings.Position.y, _bird.transform.position.z);
        }

        public void UpdateBirdRotationX()
        {
            Settings.BirdSettings.Rotation.x = float.Parse(_birdRotation[0].text.Trim());
            _bird.transform.eulerAngles = new Vector3(Settings.BirdSettings.Rotation.x, _bird.transform.eulerAngles.y, _bird.transform.eulerAngles.z);
        }

        public void UpdateBirdRotationY()
        {
            Settings.BirdSettings.Rotation.y = float.Parse(_birdRotation[1].text.Trim());
            _bird.transform.eulerAngles = new Vector3(_bird.transform.eulerAngles.x, Settings.BirdSettings.Rotation.y, _bird.transform.eulerAngles.z);
        }

        public void UpdateBirdRotationZ()
        {
            Settings.BirdSettings.Rotation.z = float.Parse(_birdRotation[2].text.Trim());
            _bird.transform.eulerAngles = new Vector3(_bird.transform.eulerAngles.x, _bird.transform.eulerAngles.y, Settings.BirdSettings.Rotation.z);
        }

        public void UpdateBirdFOV()
        {
            Settings.BirdSettings.FOV = _birdFOV.value;
            _bird.fieldOfView = Settings.BirdSettings.FOV;
            _birdFOVText.text = $"FOV ({(int)Settings.BirdSettings.FOV})";
        }

        public void UpdateBirdOffsetZ()
        {
            Settings.BirdSettings.OffsetZ = _birdOffsetZ.value;
            _bird.GetComponent<CameraFollow>().OffsetZ = Settings.BirdSettings.OffsetZ;
            _birdOffsetZText.text = $"Offset Z ({Settings.BirdSettings.OffsetZ.ToString("0.00")})";
        }

        public void UpdateBirdFollowSpeed()
        {
            Settings.BirdSettings.FollowSpeed = float.Parse(_birdFollowSpeed.text.Trim());
            _bird.GetComponent<CameraFollow>().FollowSpeed = Settings.BirdSettings.FollowSpeed;
        }
        #endregion

        #region THIRDPERSON
        public void UpdateThirdPersonPositionX()
        {
            Settings.ThirdPersonSettings.Position.x = float.Parse(_thirdPersonPosition[0].text.Trim());
            _thirdPerson.transform.position = new Vector3(Settings.ThirdPersonSettings.Position.x, _thirdPerson.transform.position.y, _thirdPerson.transform.position.z);
        }

        public void UpdateThirdPersonPositionY()
        {
            Settings.ThirdPersonSettings.Position.y = float.Parse(_thirdPersonPosition[1].text.Trim());
            _thirdPerson.transform.position = new Vector3(_thirdPerson.transform.position.x, Settings.ThirdPersonSettings.Position.y, _thirdPerson.transform.position.z);
        }

        public void UpdateThirdPersonRotationX()
        {
            Settings.ThirdPersonSettings.Rotation.x = float.Parse(_thirdPersonRotation[0].text.Trim());
            _thirdPerson.transform.eulerAngles = new Vector3(Settings.ThirdPersonSettings.Rotation.x, _thirdPerson.transform.eulerAngles.y, _thirdPerson.transform.eulerAngles.z);
        }

        public void UpdateThirdPersonRotationY()
        {
            Settings.ThirdPersonSettings.Rotation.y = float.Parse(_thirdPersonRotation[1].text.Trim());
            _thirdPerson.transform.eulerAngles = new Vector3(_thirdPerson.transform.eulerAngles.x, Settings.ThirdPersonSettings.Rotation.y, _thirdPerson.transform.eulerAngles.z);
        }

        public void UpdateThirdPersonRotationZ()
        {
            Settings.ThirdPersonSettings.Rotation.z = float.Parse(_thirdPersonRotation[2].text.Trim());
            _thirdPerson.transform.eulerAngles = new Vector3(_thirdPerson.transform.eulerAngles.x, _thirdPerson.transform.eulerAngles.y, Settings.ThirdPersonSettings.Rotation.z);
        }

        public void UpdateThirdPersonFOV()
        {
            Settings.ThirdPersonSettings.FOV = _thirdPersonFOV.value;
            _thirdPerson.fieldOfView = Settings.ThirdPersonSettings.FOV;
            _thirdPersonFOVText.text = $"FOV ({(int)Settings.ThirdPersonSettings.FOV})";
        }

        public void UpdateThirdPersonOffsetZ()
        {
            Settings.ThirdPersonSettings.OffsetZ = _thirdPersonOffsetZ.value;
            _thirdPerson.GetComponent<CameraFollow>().OffsetZ = Settings.ThirdPersonSettings.OffsetZ;
            _thirdPersonOffsetZText.text = $"Offset Z ({Settings.ThirdPersonSettings.OffsetZ.ToString("0.00")})";
        }

        public void UpdateThirdPersonFollowSpeed()
        {
            Settings.ThirdPersonSettings.FollowSpeed = float.Parse(_thirdPersonFollowSpeed.text.Trim());
            _thirdPerson.GetComponent<CameraFollow>().FollowSpeed = Settings.ThirdPersonSettings.FollowSpeed;
        }
        #endregion
        #endregion

        #region OBSTACLES
        [Header("Obstacles")]
        [SerializeField] private GameObject _airSpikes;
        [SerializeField] private GameObject _rotatingSpikes;
        [SerializeField] private GameObject _colorChangers;
        [SerializeField] private GameObject _hammers;
        [Space(10)]
        [SerializeField] private Toggle _airSpikesUI;
        [SerializeField] private Toggle _rotatingSpikesUI;
        [SerializeField] private Toggle _colorChangersUI;
        [SerializeField] private Toggle _hammersUI;


        public void ToggleAirSpikes()
        {
            Settings.AirSpikes = _airSpikesUI.isOn;
            _airSpikes.SetActive(Settings.AirSpikes);
        }

        public void ToggleRotatingSpikes()
        {
            Settings.RotatingSpikes = _rotatingSpikesUI.isOn;
            _rotatingSpikes.SetActive(Settings.RotatingSpikes);
        }

        public void ToggleColorChangers()
        {
            Settings.ColorChangers = _colorChangersUI.isOn;
            _colorChangers.SetActive(Settings.ColorChangers);
        }

        public void ToggleHammers()
        {
            Settings.Hammers = _hammersUI.isOn;
            _hammers.SetActive(Settings.Hammers);
        }
        #endregion

        #region PLAYER
        [Header("Player")]
        [SerializeField] private CollisionManager _playerColManager;
        [SerializeField] private Movement _playerMovement;
        [Space(10)]
        [SerializeField] private Toggle _affectedByColorsUI;
        [SerializeField] private TMP_InputField _forwardSpeedUI;
        [SerializeField] private TMP_InputField _sideLerpSpeedUI;

        public void ToggleAffectedByColors()
        {
            Settings.AffectedByColors = _affectedByColorsUI.isOn;
            _playerColManager.AffectedByColors = Settings.AffectedByColors;
        }

        public void SetForwardSpeed()
        {
            float value = float.Parse(_forwardSpeedUI.text.Trim());
            Settings.ForwardSpeed = value;
            _playerMovement.ForwardSpeed = Settings.ForwardSpeed;
        }

        public void SetSideLerpSpeed()
        {
            float value = float.Parse(_sideLerpSpeedUI.text.Trim());
            Settings.SideLerpSpeed = value;
            _playerMovement.SideLerpSpeed = Settings.SideLerpSpeed;
        }
        #endregion
    }
}
