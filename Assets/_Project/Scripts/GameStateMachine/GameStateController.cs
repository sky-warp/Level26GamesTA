using System;

namespace _Project.Scripts.GameStateMachine
{
    public class GameStateController
    {
        public event Action OnGameEnd;
        
        private State _state;

        public void SetState(State state)
        {
            _state = state;
            CheckState();
        }

        public void CheckState()
        {
            switch (_state)
            {
                case State.Endgame:
                    OnGameEnd?.Invoke();
                    break;
                case State.Gameplay:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}