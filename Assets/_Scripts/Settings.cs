using UnityEngine;

namespace Aezakmi
{
    public static class Settings
    {
        // Default Settings which can be manipulated within Pause Menu

        public static bool AirSpikes = true;
        public static bool RotatingSpikes = true;
        public static bool ColorChangers = true;
        public static bool Hammers = true;

        public static bool AffectedByColors = true;
        public static float ForwardSpeed = 8;
        public static float SideLerpSpeed = 12;

        public static ActiveCamera ActiveCamera = ActiveCamera.Bird;
        public static CameraSettings BirdSettings = new CameraSettings
        (
            new Vector3(35.51f, 23.3f, -69.16f),
            new Vector3(20.088f, -38.301f, 0f),
            25f,
            -41.68056f,
            4f
        );

        public static CameraSettings ThirdPersonSettings = new CameraSettings
        (
            new Vector3(0f, 7f, -41.14f),
            new Vector3(13.54f, 0f, 0f),
            75f,
            -13.92f,
            4f
        );
    }
}