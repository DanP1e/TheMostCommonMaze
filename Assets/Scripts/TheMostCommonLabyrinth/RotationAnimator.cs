using UnityEngine;

namespace TheMostCommonLabyrinth
{
    public class RotationAnimator : SimpleAnimator
    {
        [Tooltip("Определяет на сколько градусов певернётся объект за единицу высоты кривой.")]
        [SerializeField] private float _degreeMultiplier = 360;
        protected override void AnimationTick(float curveValue, float previousCurveValue)
        {
            transform.Rotate(
                Vector3.forward, 
                curveValue * _degreeMultiplier - previousCurveValue * _degreeMultiplier,
                UnityEngine.Space.Self);
        }
    }
}
