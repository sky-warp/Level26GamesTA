using UnityEngine;
using UnityEngine.Pool;

namespace _Project.Scripts.TurretShootingSystem.Projectiles
{
    public abstract class BaseObjectPool<T> where T : MonoBehaviour
    {
        protected T Prefab;

        protected bool CollectionCheck;
        protected int StartupSize;
        protected int MaxSize;

        protected IObjectPool<T> Pool;

        protected BaseObjectPool(T prefab, int startupSize, int maxSize)
        {
            Prefab = prefab;
            StartupSize = startupSize;
            MaxSize = maxSize;
            
            Pool = new ObjectPool<T>(Create, OnGet, OnRelease, OnDestroy, CollectionCheck, StartupSize, MaxSize);
        }

        public abstract T Create();
        public abstract void OnGet(T obj);
        public abstract void OnRelease(T obj);
        public abstract void OnDestroy(T obj);
    }
}