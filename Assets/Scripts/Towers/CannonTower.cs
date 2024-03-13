using UnityEngine;

namespace Towers
{
	public class CannonTower : TowerBase
	{
		[Header("4. Настройка скорости поворота")]
		[SerializeField] private float _speedRotate = 1f;

		private float _minAngleCannon = -30f;
		private float _maxAngleCannon = -50f;

		[SerializeField] private Transform _cannonTower;

		private Quaternion targetAngle;
		private Quaternion targetQuatTower;

		private void Update()
		{
			base.Update();
			LookAtFocus();
		}

        private void LookAtFocus()
		{
			if (_monsterInFocus != null)
			{
				var projectileTime = projectile.GetTimeFly(_shootPoint.position,
					_monsterInFocus.transform.position);
				var gipotPosit = _monsterInFocus.GetVectorAfterTime(projectileTime);
				targetAngle = Quaternion.LookRotation(gipotPosit - transform.position);

				var dist = Vector3.Distance(transform.position, _monsterInFocus.transform.position);
				float targetAngleTower = (dist - _minRange) / (_range - _minRange)
					* (_maxAngleCannon - _minAngleCannon) + _minAngleCannon;
				targetQuatTower = Quaternion.Euler(targetAngleTower, 0, 0);
			}

			var newRotate = Quaternion.Lerp(transform.rotation, targetAngle, Time.deltaTime * _speedRotate);
			float angle = newRotate.eulerAngles.y;
			transform.rotation = Quaternion.Euler(0, angle, 0);

			var angleTower = Quaternion.Lerp(_cannonTower.localRotation, targetQuatTower, Time.deltaTime * _speedRotate);
			_cannonTower.localRotation = angleTower;
		}
	}
}