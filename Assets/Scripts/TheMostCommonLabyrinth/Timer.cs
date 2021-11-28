using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheMostCommonLabyrinth
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private bool _isLoop = true;
        [SerializeField] private float _expirationTime;

        public UnityEvent TimerTick;

        protected virtual void OnEnable()
        {
            StartCoroutine(TimerCorutine());
        }
        protected virtual void OnDisable() 
        {
            StopAllCoroutines();
        }

        private IEnumerator TimerCorutine() 
        {
            do
            {
                yield return new WaitForSeconds(_expirationTime);
                TimerTick?.Invoke();
            } while (_isLoop);
        }
    }
}
