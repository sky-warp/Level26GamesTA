using UnityEngine;

namespace _Project.Scripts.Turret
{
    public class TurretGun
    {
        public GameObject Gun { get; private set; }

        public void Init(GameObject turretGun)
        {
            Gun = turretGun;
        }
    }
}