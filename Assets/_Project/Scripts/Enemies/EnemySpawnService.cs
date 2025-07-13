using System.Collections;
using _Project.Scripts.Factories;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    public class EnemySpawnService
    {
        private BaseMonoFactory _jetFactory;
        private BattleController _battleController;
        private int _wavesNumber;
        private bool _isDestroyed;

        public EnemySpawnService(BaseMonoFactory jetFactory, BattleController battleController, int wavesNumber)
        {
            _jetFactory = jetFactory;
            _battleController = battleController;
            _wavesNumber = wavesNumber;
        }

        public IEnumerator SpawnJetWaves()
        {
            for (int i = 0; i < _wavesNumber; i++)
            {
                var jet = _jetFactory.Create().GetComponent<Jet>();

                _battleController.SetCurrentEnemy(jet);
                
                jet.MoveFlyingEnemy();

                yield return new WaitUntil(() => jet.IsDestroyed);
                
                _battleController.ResetCurrentEnemy();
                
                yield return new WaitForSeconds(2f);
            }
        }
    }
}