using UnityEngine;
using UnityEngine.Events;

namespace TheMostCommonLabyrinth
{
    [RequireComponent(typeof(Collider))]
    public class UsableObject : MonoBehaviour
    {
        public UnityEvent<UsableObject> Used;
        protected virtual void OnCollisionEnter(Collision collision)
        {
            Hero user = collision.gameObject.GetComponent<Hero>();
            if (user != null)
                Used?.Invoke(this);
        }
    }
}
