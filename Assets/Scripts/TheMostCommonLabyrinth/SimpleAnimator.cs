using UnityEngine;

/// <summary>
/// Двигает объект вперёд или назад по заданной кривой
/// </summary>
namespace TheMostCommonLabyrinth
{
    public abstract class SimpleAnimator : MonoBehaviour
    {
        private float oldValue = 0;
        private float timer = 0;
        [Tooltip("Скорость проигрывания анмации.")]
        [SerializeField] private float _animationSpeed = 1;
        [Range(0, 1)]
        [Tooltip("\"Смещение\", определяет начало анимации.")]
        [SerializeField] private float _bias = 0;
        [Tooltip("Кривая анимации движения вперёд.")]
        [SerializeField] private AnimationCurve _moveAnimationCurve;

        private void Start()
        {
            timer = GetCurveTime() * _bias;
        }
        private void FixedUpdate()
        {
            float curveVal = _moveAnimationCurve.Evaluate(timer);
            AnimationTick(curveVal, oldValue);
            timer += Time.fixedDeltaTime * _animationSpeed;
            oldValue = curveVal;
        }
        private float GetCurveTime()
            => _moveAnimationCurve[_moveAnimationCurve.length - 1].time;

        protected abstract void AnimationTick(float curveValue, float previousCurveValue);

    } 
}
