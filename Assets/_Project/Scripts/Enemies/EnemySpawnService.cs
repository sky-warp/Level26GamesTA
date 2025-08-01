using System.Collections;
using _Project.Scripts.Factories;
using _Project.Scripts.GameStateMachine;
using _Project.Scripts.Infrаstructure;
using _Project.Scripts.UI;
using UnityEngine;

namespace _Project.Scripts.Enemies
{
    public class EnemySpawnService
    {
        private BaseMonoFactory _jetFactory;
        private BattleController _battleController;
        private GameStateController _gameStateController;
        private UIAnimationsController _animationsController;
        private int _wavesNumber;
        private bool _isDestroyed;

        public EnemySpawnService(BaseMonoFactory jetFactory, BattleController battleController,
            UIAnimationsController animationsController, GameStateController stateController, int wavesNumber)
        {
            _jetFactory = jetFactory;
            _battleController = battleController;
            _animationsController = animationsController;
            _gameStateController = stateController;
            _wavesNumber = wavesNumber;
        }

        public IEnumerator SpawnJetWaves()
        {
            for (int i = 0; i < _wavesNumber; i++)
            {
                _animationsController.SetWaveNumberText(i + 1, _wavesNumber);
                _animationsController.ShowNumberOfWaves();

                _animationsController.SetDestroyedJetsCountText(i + 1);

                var jet = _jetFactory.Create().GetComponent<Jet>();

                _battleController.SetCurrentEnemy(jet);

                jet.MoveFlyingEnemy();

                yield return new WaitUntil(() => jet.IsDestroyed);

                _battleController.ResetCurrentEnemy();

                _animationsController.SetDestroyedJetsCountText(i + 1);

                if (i + 1 != _wavesNumber)
                    yield return new WaitForSeconds(2f);
            }

            _animationsController.ShowMissionCompleteText().Forget();

            _gameStateController.SetState(State.Endgame);
        }
    }
}