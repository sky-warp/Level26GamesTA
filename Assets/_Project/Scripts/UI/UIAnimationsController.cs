using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class UIAnimationsController : MonoBehaviour
    {
        [SerializeField] private GameObject _numberOfWaves;

        private TextMeshProUGUI _numberOfWavesText;
        private RectTransform _rectTransform;
        private Vector2 _startPosition;

        public void Init()
        {
            _numberOfWavesText = _numberOfWaves.GetComponentInChildren<TextMeshProUGUI>();
            _rectTransform = _numberOfWaves.GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition;
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
                .OnComplete(() =>
                {
                    _rectTransform.DOAnchorPosY(_startPosition.y, 2.0f);
                });
        }
    }
}