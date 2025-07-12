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

        public ParticleSystem Create()
        {
            var effect = GameObject.Instantiate(_effect);    
            
            return effect;
        }
    }
}