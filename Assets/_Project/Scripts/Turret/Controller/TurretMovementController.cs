using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretMovement;
using UnityEngine;

namespace _Project.Scripts.Turret.Controller
{
    public class TurretMovementController : MonoBehaviour
    {
        public bool IsTouched { get; private set; }

        private GameObject _turretGun;

        private IInputable _inputManager;

        private float _xInput;
        private float _yInput;

        private float _currentGunRotation = 0f;

        private float _rotationSpeed;
        private float _sensitivity;

        private void Awake()
        {
            _turretGun = GetComponentInChildren<TurretGun>().gameObject;
        }

        public void Init(IInputable inputable, TurretModel model)
        {
            _inputManager = inputable;
            _rotationSpeed = model.TurretSpeed;
            _sensitivity = model.Sensitivity;
        }

        private void Update()
        {
            _xInput = _inputManager.GetAxisHorizontal();
            _yInput = _inputManager.GetAxisVertical();

            IsTouched = Mathf.Abs(_xInput) > 0 || Mathf.Abs(_yInput) > 0 || Input.touchCount > 0;

            _currentGunRotation = -_yInput;
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, -_xInput * _rotationSpeed * Time.deltaTime, 0);

            float currentX = _turretGun.transform.localEulerAngles.x;

            if (currentX > 180f)
                currentX -= 360f;

            float gunAngleX = Mathf.Clamp(currentX - _currentGunRotation * _rotationSpeed, -10, 10);

            float smoothedX =
                Mathf.LerpAngle(_turretGun.transform.localEulerAngles.x, gunAngleX, _sensitivity * Time.deltaTime);

            _turretGun.transform.localRotation = Quaternion.Euler(smoothedX, 0f, 0f);
        }
    }
}