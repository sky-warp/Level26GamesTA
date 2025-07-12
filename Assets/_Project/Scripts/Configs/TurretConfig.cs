using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "TurretConfig", menuName = "Configs/TurretConfig")]
    public class TurretConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float TurretSpeed { get; private set; }
        [field: SerializeField] public float Sensitivity { get; private set; }
        [field: SerializeField] public float ShootInterval { get; private set; }
    }
}