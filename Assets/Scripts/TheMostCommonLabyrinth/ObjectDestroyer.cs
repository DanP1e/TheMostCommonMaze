using UnityEngine;

namespace TheMostCommonLabyrinth
{
    public class ObjectDestroyer : MonoBehaviour
    {
        [SerializeField] private GameObject _targetGameObject;

        public void DestroyObject()
            => Destroy(_targetGameObject);
    } 
}
