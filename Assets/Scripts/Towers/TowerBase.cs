using Monstrs;
using Projectile;
using TimerController;
using UnityEngine;

namespace Towers
{
    public class TowerBase : MonoBehaviour
    {
        [SerializeField] private float _shootInterval = 1f;
        private float _shotingTimer = 0f;

        [SerializeField] protected float _minRange = 2f;
        [SerializeField] protected float _range = 5f;

        [SerializeField] protected ProjectileBase projectile;
        [SerializeField] protected Transform _shootPoint;

        protected Monster _monsterInFocus;
        private StateTower _stateTower;

        private void Awake()
        {
            _shotingTimer = _shootInterval;
        }

        protected void Update()
        {
            RunState();
        }

        private void RunState()
        {
            switch (_stateTower)
            {
                case StateTower.Reloading:
                    _shotingTimer = Timer.Run(_shotingTimer, _shootInterval, ReloadComplete);
                    break;
                case StateTower.FindingTarget:
                    FindNewTarget();
                    break;
                case StateTower.Shooting:
                    TryShoot();
                    break;
            }
        }

        private void ReloadComplete()
        {
            _stateTower = _monsterInFocus == null
                ? StateTower.FindingTarget
                : StateTower.Shooting;
        }

        private void FindNewTarget()
        {
            _monsterInFocus = MonstersController.Instance.GetNearMonster(transform.position, _range);
            if (_monsterInFocus != null)
            {
                _monsterInFocus.removeMonster += RemoveTarget;
                _stateTower = StateTower.Shooting;
            }
        }

        private void RemoveTarget(Monster monster)
        {
            _monsterInFocus.removeMonster -= RemoveTarget;
            _monsterInFocus = null;
        }

        private void TryShoot()
        {
            if (_monsterInFocus != null &&
                _monsterInFocus.DistanceTo(transform.position) < _range &&
                _monsterInFocus.DistanceTo(transform.position) > _minRange)
            {
                var newShoot = Instantiate(projectile, _shootPoint.position, Quaternion.identity);
                var projectileTime = projectile.GetTimeFly(_shootPoint.position,
                        _monsterInFocus.transform.position);
                var gipotPosit = _monsterInFocus.GetVectorAfterTime(projectileTime);

                newShoot.InitProjectile(_shootPoint.position,
                    gipotPosit,
                    _monsterInFocus);
                _stateTower = StateTower.Reloading;
            }
            else
            {
                _stateTower = StateTower.FindingTarget;
            }
        }
    }
}