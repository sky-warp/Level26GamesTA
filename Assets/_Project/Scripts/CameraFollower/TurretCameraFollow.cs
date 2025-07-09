using UnityEngine;

namespace _Project.Scripts.CameraFollower
{
    public class TurretCameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = new Vector3(-1.45f, 2, -4.55f);

        private Transform _turretBase;
        private Transform _turretGun;

        public void Init(Transform basePosition, Transform gunPosition)
        {
            _turretBase = basePosition;
            _turretGun = gunPosition;
        }

        private void LateUpdate()
        {
            float y = _turretBase.eulerAngles.y;
            float x = _turretGun.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(x, y, 0f);

            transform.position = _turretBase.position + rotation * offset;

            transform.rotation = rotation;
        }
    }
}