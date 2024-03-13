using UnityEngine;

namespace Projectile
{
    public class ProjectileBase : MonoBehaviour
	{
		protected Vector3 _startFly;
		protected Vector3 _endFly;
		private Monster _targetEnemy;
		protected float _timeFly = 0;
		private float _maxTimeFly;
		protected float _pathPosit => _timeFly / _maxTimeFly;

		[SerializeField] private float _speedFly = 20f;
		[SerializeField] private int _damage = 10;

		public virtual void InitProjectile(Vector3 startP, Vector3 endP, Monster enemy)
		{
			_targetEnemy = enemy;
			_startFly = startP;
			_endFly = endP;
			_maxTimeFly = GetTimeFly(startP, endP);
		}

		void Update()
		{
			Fly();
			CheckEnd();
		}

		public float GetTimeFly(Vector3 startP, Vector3 endP)
		{
			var dist = Vector3.Distance(startP, endP);
			return dist / _speedFly;
		}

		protected virtual void Fly()
		{
			_timeFly += Time.deltaTime;
			transform.position = Vector3.Lerp(_startFly, _endFly, _pathPosit);
		}

		protected virtual void CheckEnd()
		{
			if (_timeFly >= _maxTimeFly)
			{
				EndShooting();
			}
		}

		private void EndShooting()
		{
			if (_targetEnemy != null)
			{
				_targetEnemy.GetDamage(_damage);
			}
			Destroy(gameObject);
		}
	}
}