using _Project.Scripts.Turret.Model;
using _Project.Scripts.TurretMovement;
using UnityEngine;

namespace _Project.Scripts.Controller
{
    public class TurretMovementController : MonoBehaviour
    {
        public bool IsTouched { get; private set; }

        private GameObject _turretTopside;

        private IInputable _inputManager;

        private float _xInput;
        private float _yInput;

        private float _currentGunRotation = 0f;

        private float _rotationSpeed;
        private float _sensitivity;

        private bool _isEnable = true;

        public void Init(IInputable inputSystem, TurretModel model, GameObject turretTopside)
        {
            _inputManager = inputSystem;
            _rotationSpeed = model.TurretSpeed;
            _sensitivity = model.Sensitivity;
            _turretTopside = turretTopside;
        }

        public void TurnOffInput()
        {
            _isEnable = false;
            IsTouched = false;
            _xInput = 0;
            _yInput = 0;
        }

        private void Update()
        {
            if (_isEnable)
            {
                _xInput = _inputManager.GetAxisHorizontal();
                _yInput = _inputManager.GetAxisVertical();

                IsTouched = Mathf.Abs(_xInput) > 0 || Mathf.Abs(_yInput) > 0 || Input.touchCount > 0;

                _currentGunRotation = -_yInput;
            }
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, -_xInput * _rotationSpeed * Time.deltaTime, 0);

            float currentX = _turretTopside.transform.localEulerAngles.x;

            if (currentX > 180f)
                currentX -= 360f;

            float gunAngleX = Mathf.Clamp(currentX - _currentGunRotation * _rotationSpeed, -40, 10);

            float smoothedX =
                Mathf.LerpAngle(_turretTopside.transform.localEulerAngles.x, gunAngleX, _sensitivity * Time.deltaTime);

            _turretTopside.transform.localRotation = Quaternion.Euler(smoothedX, 0f, 0f);
        }
    }
}