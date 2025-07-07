using _Project.Scripts.Turret.Controller;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.TurretAnimations
{
    public class TurretAnimationController : IInitializable, ITickable
    {
        private Animator _turretAnimator;

        private TurretMovementController _controller;

        public void Init(TurretMovementController turretMovementController)
        {
            _controller = turretMovementController;
        }

        public void Initialize()
        {
            _turretAnimator = _controller.GetComponentInChildren<Animator>();
        }

        public void Tick()
        {
            _turretAnimator.SetBool("Attack", _controller.IsTouched);
        }
    }
}