using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TheMostCommonLabyrinth
{
    public class RandomSoundPlayer : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _sounds;
        [SerializeField] private AudioSource _audioSource;

        public UnityEvent _soundPlayed;

        private IEnumerator Timer(float waitTime) 
        {
            yield return new WaitForSeconds(waitTime);
            _soundPlayed?.Invoke();
        }

        public void PlayRadomSound() 
        {
            if (_sounds.Count == 0)
                return;
            _audioSource.clip = _sounds[Random.Range(0, _sounds.Count)];
            _audioSource.Play();
            StartCoroutine(Timer(_audioSource.clip.length));
        }

    } 
}
