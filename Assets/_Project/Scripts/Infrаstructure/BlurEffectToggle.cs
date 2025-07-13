using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace _Project.Scripts.Infrаstructure
{
    public class BlurEffectToggle : MonoBehaviour
    {
        private Volume _volume;
        private DepthOfField _dof;

        private void Start()
        {
            _volume = GetComponent<Volume>();

            if (_volume.profile.TryGet<DepthOfField>(out var dof))
            {
                _dof = dof;
            }
        }

        public void BlurBackground()
        {
            _dof.active = true;
            _dof.focusDistance.value = 0.1f;
        }
    }
}