using _Project.Scripts.Turret;
using UnityEngine;

namespace _Project.Scripts.CameraFollower
{
    public class TurretCameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 offset = new Vector3(0, 2, -5);

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
            float x = _turretGun.localEulerAngles.x;

            Quaternion rotation = Quaternion.Euler(0f, y, 0f);

            transform.position = _turretBase.position + rotation * offset;

            transform.rotation = Quaternion.Euler(x, y, 0f);
        }
    }
}