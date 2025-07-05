using UnityEngine;

namespace _Project.Scripts.Factories
{
    public class TurretFactory : BaseMonoFactory
    {
        public TurretFactory(GameObject prefab) : base(prefab)
        {
        }

        public override GameObject Create()
        {
            var instance = GameObject.Instantiate(Prefab);

            return instance;
        }
    }
}