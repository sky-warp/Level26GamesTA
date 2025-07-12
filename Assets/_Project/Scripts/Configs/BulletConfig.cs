using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Configs/ProjectileConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}