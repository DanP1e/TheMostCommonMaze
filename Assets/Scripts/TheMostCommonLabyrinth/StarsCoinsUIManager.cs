using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheMostCommonLabyrinth
{
    //Да, да, да, я слышал про принцип единственной ответственности,
    //но я писал это на скорую руку и мне лень))
    public class StarsCoinsUIManager : MonoBehaviour
    {
        [Tooltip("Текст который отоброжает подсчет собраных монет.")]
        [SerializeField] private Text _coinsColetedText;
        [Tooltip("Объект в котором будет создаваться \"звзды\"")]
        [SerializeField] private Transform _starsContainer;
        [Tooltip("\"Звзда\" которая будет создаваться")]
        [SerializeField] private GameObject _uiStarPrefab;
        [SerializeField] private StarsCollector _starsCollector;

        private void Start()
        {
            UpdateText();
            _starsCollector.UsableObjectCollected.AddListener(OnCoinCollected);
            _starsCollector.StarCollected.AddListener(OnStarCollected);
        }

        private void OnStarCollected(int arg0)
        {
            var newStarObject = Instantiate(_uiStarPrefab);
            newStarObject.transform.SetParent(_starsContainer);
        }
        private void OnCoinCollected(int arg0)
        {
            UpdateText();
        }
        private string UpdateText()
        => _coinsColetedText.text = $"{_starsCollector.CollectedObjects} / { _starsCollector.CollectableObjectsCount}";
    } 
}
