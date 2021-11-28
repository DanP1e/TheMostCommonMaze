using UnityEngine;
using UnityEngine.Events;

namespace TheMostCommonLabyrinth
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hero : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        [SerializeField] private float _speedMultiplier;       

        public UnityEvent Dead;

        protected virtual void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Killer>() != null)
                Dead?.Invoke();
        }
        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        public void Move(Vector3 translation)
        {
            translation *= _speedMultiplier;
            translation.y = _rigidbody.velocity.y;
            _rigidbody.velocity = translation;
        }
    }
}
