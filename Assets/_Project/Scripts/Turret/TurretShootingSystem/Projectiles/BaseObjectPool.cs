using _Project.Scripts.Configs;
using UnityEngine;
using UnityEngine.Pool;

namespace _Project.Scripts.TurretShootingSystem.Projectiles
{
    public abstract class BaseObjectPool<T> where T : MonoBehaviour
    {
        public IObjectPool<T> Pool;

        protected T Prefab;

        protected bool CollectionCheck;
        protected int StartupSize;
        protected int MaxSize;

        protected BaseObjectPool(T prefab, ProjectilePoolConfig config)
        {
            Prefab = prefab;
            StartupSize = config.StartupSize;
            MaxSize = config.MaxSize;

            Pool = new ObjectPool<T>(Create, OnGet, OnRelease, OnDestroy, CollectionCheck, StartupSize, MaxSize);
        }

        public abstract T Create();
        public abstract void OnGet(T obj);
        public abstract void OnRelease(T obj);
        public abstract void OnDestroy(T obj);
    }
}