using System;
using _Project.Scripts.Factories;
using _Project.Scripts.TurretShootingSystem.Projectiles;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour
    {
        public bool IsDestroyed { get; protected set; }
        public Action<Projectile> OnHit;
        protected int Health;
        protected float Speed;
        protected VisualEffectFactory VisualEffectFactory;
        protected Vector3 Destination;

        public void Init(float speed, int health, VisualEffectFactory visualEffectFactory, Vector3 destination)
        {
            Speed = speed;
            Health = health;
            VisualEffectFactory = visualEffectFactory;
            Destination = destination;
        }

        public abstract void MoveFlyingEnemy();
        public abstract void DestroyEnemy();
        public abstract void TakeDamage(Projectile projectile);
    }
}