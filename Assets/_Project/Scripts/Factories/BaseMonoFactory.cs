using UnityEngine;

namespace _Project.Scripts.Factories
{
    public abstract class BaseMonoFactory
    {
        protected GameObject Prefab;

        protected BaseMonoFactory(GameObject prefab)
        {
            Prefab = prefab;
        }

        public abstract GameObject Create();
    }
}