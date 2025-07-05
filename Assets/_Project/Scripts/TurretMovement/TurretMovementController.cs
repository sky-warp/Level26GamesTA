using _Project.Scripts.Turret.Model;
using UnityEngine;

namespace _Project.Scripts.TurretMovement
{
    public class TurretMovementController : MonoBehaviour
    {
        [SerializeField] private GameObject _turretGun;
        
        private IInputable _inputManager;

        private float _xInput;
        private float _yInput;

        private float _rotationSpeed;

        public void Init(IInputable inputable, TurretModel model)
        {
            _inputManager = inputable;
            _rotationSpeed = model.TurretSpeed;
        }

        private void Update()
        {
            _xInput = _inputManager.GetAxisHorizontal();
            _yInput = _inputManager.GetAxisVertical();
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, -_xInput * _rotationSpeed * Time.deltaTime, 0);
            _turretGun.transform.Rotate(_yInput * _rotationSpeed * Time.deltaTime, 0, 0);
        }
    }
}