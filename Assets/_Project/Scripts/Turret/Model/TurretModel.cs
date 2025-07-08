using _Project.Scripts.Configs;

namespace _Project.Scripts.Turret.Model
{
    public class TurretModel
    {
        public readonly float TurretSpeed;
        public readonly float Sensitivity;
        public readonly float ShootInterval;

        public TurretModel(TurretConfig config)
        {
            TurretSpeed = config.TurretSpeed;
            Sensitivity = config.Sensitivity;
            ShootInterval = config.ShootInterval;
        }
    }
}