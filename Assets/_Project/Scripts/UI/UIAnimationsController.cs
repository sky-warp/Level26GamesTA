using System;
using _Project.Scripts.Infrаstructure;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class UIAnimationsController : MonoBehaviour
    {
        [SerializeField] private BlurEffectToggle _blurEffectToggle;

        [SerializeField] private GameObject _numberOfWaves;
        [SerializeField] private GameObject _missionComplete;
        [SerializeField] private GameObject _endgameWindow;

        [SerializeField] private TextMeshProUGUI _destroyedJetsCountText;

        [SerializeField] private Button _continueButton;

        public event Action OnContinueButtonPressed;

        private TextMeshProUGUI _numberOfWavesText;
        private RectTransform _rectTransform;
        private Vector2 _startPosition;

        private void Start()
        {
            _continueButton.onClick.AddListener(() => OnContinueButtonPressed?.Invoke());
        }

        public void Init()
        {
            _numberOfWavesText = _numberOfWaves.GetComponentInChildren<TextMeshProUGUI>();
            _rectTransform = _numberOfWaves.GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition;

            _missionComplete.SetActive(false);
            _endgameWindow.SetActive(false);
        }

        public void SetDestroyedJetsCountText(int destroyedJetsCount)
        {
            _destroyedJetsCountText.text = $"JETS - {destroyedJetsCount}";
        }

        public void SetWaveNumberText(int currentNumberOfWaves, int totalNumberOfWaves)
        {
            _numberOfWavesText.text = $"NEW WAVE\n{currentNumberOfWaves} OF {totalNumberOfWaves}";
        }

        public void ShowNumberOfWaves()
        {
            _rectTransform.DOAnchorPosY(-100, 3.0f)
                .SetEase(Ease.Linear)
                .SetLoops(1, LoopType.Yoyo)
                .OnComplete(() => { _rectTransform.DOAnchorPosY(_startPosition.y, 2.0f); });
        }

        public async UniTaskVoid ShowMissionCompleteText()
        {
            _missionComplete.SetActive(true);

            await UniTask.WaitForSeconds(2.0f);

            _missionComplete.SetActive(false);

            ShowEndgameWindow();
        }

        private void ShowEndgameWindow()
        {
            _endgameWindow.SetActive(true);
            _blurEffectToggle.BlurBackground();
        }

        private void OnDestroy()
        {
            _continueButton.onClick.RemoveAllListeners();
        }
    }
}