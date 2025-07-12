using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Vector3 SpawnPoint { get; private set; }
    }
}