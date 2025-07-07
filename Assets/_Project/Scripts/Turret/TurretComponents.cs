using UnityEngine;

namespace _Project.Scripts.Turret
{
    public class TurretComponents
    {
        public GameObject TopsideBase { get; private set; }
        public GameObject Gun { get; private set; }

        public void Init(GameObject turretGun, GameObject topside)
        {
            Gun = turretGun;
            TopsideBase = topside;
        }
    }
}