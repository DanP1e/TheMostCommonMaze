using UnityEngine;

namespace TheMostCommonLabyrinth
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private GameObject _teleportableObject;
        [SerializeField] private Transform _teleportPoint;

        public void Teleport() 
        {
            _teleportableObject.transform.position = _teleportPoint.position;
        }
    }
}
