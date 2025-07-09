using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "ProjectilePoolConfig", menuName = "Configs/ProjectilePoolConfig")]
    public class ProjectilePoolConfig : ScriptableObject
    {
        [field: SerializeField] public int StartupSize { get; private set; }
        [field: SerializeField] public int MaxSize { get; private set; }
    }
}