using _Project.Scripts.Configs;

namespace _Project.Scripts.Turret.Model
{
    public class TurretModel
    {
        public readonly float TurretSpeed;

        public TurretModel(TurretConfig config)
        {
            TurretSpeed = config.TurretSpeed;
        }
    }
}