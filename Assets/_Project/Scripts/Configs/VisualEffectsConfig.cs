using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "VisualEffectsConfig", menuName = "Configs/VisualEffectsConfig")]
    public class VisualEffectsConfig : ScriptableObject
    {
        [field: SerializeField] public ParticleSystem JetDestroyEffect { get; private set; }
    }
}