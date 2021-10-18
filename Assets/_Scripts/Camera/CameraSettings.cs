using UnityEngine;

namespace Aezakmi
{
    public enum ActiveCamera
    {
        Bird,
        ThirdPerson
    }

    public struct CameraSettings
    {
        public Vector2 Position;
        public Vector3 Rotation;
        public float FOV;
        public float OffsetZ;
        public float FollowSpeed;

        public CameraSettings(Vector2 position, Vector3 rotation, float FOV, float offsetZ, float FollowSpeed)
        {
            this.Position = position;
            this.Rotation = rotation;
            this.FOV = FOV;
            this.OffsetZ = offsetZ;
            this.FollowSpeed = FollowSpeed;
        }
    }
}