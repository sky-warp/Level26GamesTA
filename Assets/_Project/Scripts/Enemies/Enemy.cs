using _Project.Scripts.Factories;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour
    {
        public bool IsDestroyed { get; protected set; }
        protected VisualEffectFactory VisualEffectFactory;
        protected float Speed;
        protected Vector3 Destination;

        public void Init(float speed, VisualEffectFactory visualEffectFactory, Vector3 destination)
        {
            Speed = speed;
            VisualEffectFactory = visualEffectFactory;
            Destination = destination;
        }
        
        public abstract void MoveFlyingEnemy();
        public abstract void DestroyEnemy();
    }
}