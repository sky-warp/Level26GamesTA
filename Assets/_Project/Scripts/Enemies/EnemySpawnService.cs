using System.Collections;
using _Project.Scripts.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Enemies
{
    public class EnemySpawnService : IInitializable
    {
        private BaseMonoFactory _jetFactory;
        private bool _isDestroyed;

        public EnemySpawnService(BaseMonoFactory jetFactory)
        {
            _jetFactory = jetFactory;
        }

        public void Initialize()
        {
        }

        public IEnumerator SpawnJetWaves(int wavesNumber)
        {
            for (int i = 0; i < wavesNumber; i++)
            {
                var jet = _jetFactory.Create().GetComponent<Jet>();

                jet.MoveFlyingEnemy();

                yield return new WaitUntil(() => jet.IsDestroyed);
            }
        }
    }
}