using UnityEngine;
namespace TheMostCommonLabyrinth
{
    public class PositionAnimator : SimpleAnimator
    {
        [SerializeField] private float _distanceMultiplier = 1;
        protected override void AnimationTick(float curveValue, float previousCurveValue)
            => transform.position += transform.forward * (curveValue - previousCurveValue) * _distanceMultiplier;
    }
}
