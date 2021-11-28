using UnityEngine;

namespace TheMostCommonLabyrinth
{
    public class HeroMovementController : MonoBehaviour
    {       
        private Camera _mainCamera;

        [SerializeField] private Hero _hero;
        [SerializeField] private AnimationCurve _speedByDistance;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }            
        private void FixedUpdate()
        {

            if (Input.GetMouseButton(0))
            {
                //Получаем точку к которой нужно двигаться
                Vector3 movePoint = GetMovePoint(Input.mousePosition);

                //Получаем смещение в которое нужно двигать персонажа           
                Vector3 moveVector = movePoint - _hero.transform.position;
                moveVector.y = 0;
                float speedFactor = _speedByDistance.Evaluate(moveVector.magnitude);
                moveVector.Normalize();
                moveVector *= speedFactor * Time.fixedDeltaTime;

                //Двигаем персонажа
                _hero.Move(moveVector);
            }
            else
            {
                //Останавливаем персонажа
                _hero.Move(Vector3.zero);
            }
        }
        private Vector3 GetMovePoint(Vector2 mouseScreenPosition)
        {
            //Создаем виртуальную плоскость на высоте персонажа
            Plane plane = new Plane(Vector3.up, _hero.transform.position);

            //Пускаем луч в виртуальную плоскость
            Ray ray = _mainCamera.ScreenPointToRay(mouseScreenPosition);
            float rayDistance = 0;         
            plane.Raycast(ray, out rayDistance);           

            //Получаем точку попадания луча
            return ray.GetPoint(rayDistance);
        }
    }
}
