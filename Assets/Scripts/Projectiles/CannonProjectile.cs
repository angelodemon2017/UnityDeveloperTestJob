using Projectile;
using UnityEngine;

public class CannonProjectile : ProjectileBase
{
    [Header("Как один из вариантов")]
    [SerializeField] private AnimationCurve _verticalShift;

    protected override void Fly()
    {
        _timeFly += Time.deltaTime;
        var shift = _verticalShift.Evaluate(_pathPosit);
        var newPos = Vector3.Lerp(_startFly, _endFly, _pathPosit);
        newPos.y += shift;
        transform.position = newPos;
    }
}