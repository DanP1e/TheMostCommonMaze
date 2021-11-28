using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TheMostCommonLabyrinth
{
    public class StarsCollector : MonoBehaviour
    {
        private int _collectedStars = 0;
        private int _collectedObjects = 0;
        private int? _collectableObjectsCount = null;

        [Tooltip("Устанавливает сколько всего можно получить звезд.")]
        [SerializeField] private int _maxStarsCount = 3;
        [Tooltip("За \"подбор\" этих предметов начисляются звезды.")]
        [SerializeField] private List<UsableObject> _collectableObjects;

        [Tooltip("Вызывается при начислении звезды." +
            "Передает текущее количество звезд.")]
        public UnityEvent<int> StarCollected;
        [Tooltip("Вызывается при подборе собираемого объекта." +
            "Передает текущее количество собраных объектов.")]
        public UnityEvent<int> UsableObjectCollected;

        public int CollectedStars { get => _collectedStars; }
        public int CollectedObjects { get => _collectedObjects; }
        public int CollectableObjectsCount
        {
            get
            {
                if (_collectableObjectsCount == null)
                    _collectableObjectsCount = _collectableObjects.Count;

                return (int)_collectableObjectsCount;
            }
        }

        private void Start() 
        {
            _collectableObjectsCount = _collectableObjects.Count;
            foreach (var item in _collectableObjects)
            {
                item.Used.AddListener(OnUsableObjectUsed);
            }
        }
        private void OnUsableObjectUsed(UsableObject obj)
        {
            _collectedObjects++;
            obj.Used.RemoveListener(OnUsableObjectUsed);
            _collectableObjects.Remove(obj);
            UsableObjectCollected?.Invoke(_collectedObjects);
            UpdateStarsValue();
        }
        private void UpdateStarsValue()
        {
            int starsCount = (int)((float)_collectedObjects * (_maxStarsCount / (float)_collectableObjectsCount));
            if (starsCount != _collectedStars)
            {
                _collectedStars = starsCount;
                StarCollected?.Invoke(_collectedStars);
            }
        }
    }
}
