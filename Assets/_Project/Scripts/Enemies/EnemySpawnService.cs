using System.Collections;
using _Project.Scripts.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Enemies
{
    public class EnemySpawnService
    {
        private BaseMonoFactory _jetFactory;
        private int _wavesNumber;
        private bool _isDestroyed;

        public EnemySpawnService(BaseMonoFactory jetFactory, int wavesNumber)
        {
            _jetFactory = jetFactory;
            _wavesNumber = wavesNumber;
        }

        public IEnumerator SpawnJetWaves()
        {
            for (int i = 0; i < _wavesNumber; i++)
            {
                var jet = _jetFactory.Create().GetComponent<Jet>();

                jet.MoveFlyingEnemy();

                yield return new WaitUntil(() => jet.IsDestroyed);
            }
        }
    }
}