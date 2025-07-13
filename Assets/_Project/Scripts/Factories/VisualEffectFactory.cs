using UnityEngine;

namespace _Project.Scripts.Factories
{
    public class VisualEffectFactory
    {
        private ParticleSystem _effect;

        public VisualEffectFactory(ParticleSystem effect)
        {
            _effect = effect;
        }

        public ParticleSystem Create(Vector3 position)
        {
            var effect = GameObject.Instantiate(_effect, position, Quaternion.identity);    
            
            return effect;
        }
    }
}