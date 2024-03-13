using UnityEngine;
using System.Collections;
using Monstrs;

public class Monster : MonoBehaviour
{
	private Transform m_moveTarget;
	public float m_speed = 5f;
	public int m_maxHP = 30;
	const float m_reachDistance = 0.3f;

	public int m_hp;
	public System.Action<Monster> removeMonster;

	public void Init(Transform newTarget)
	{
		m_moveTarget = newTarget;
		m_hp = m_maxHP;
	}

	public void MoveTo()
	{
		if (m_moveTarget == null)
			return;

		transform.position = GetVectorAfterTime(Time.deltaTime);

		if (Vector3.Distance(transform.position, m_moveTarget.transform.position) <= m_reachDistance)
		{
			removeMonster?.Invoke(this);
			return;
		}
	}

	public float DistanceTo(Vector3 targetTo)
    {
		return Vector3.Distance(transform.position, targetTo);
    }

	public void GetDamage(int damage)
    {
		m_hp -= damage;
		if (m_hp <= 0)
		{
			removeMonster?.Invoke(this);
		}
    }

	public Vector3 GetVectorAfterTime(float time)
	{
		var dist = Vector3.Distance(transform.position, m_moveTarget.position);
		var maxTime = dist / m_speed;
		return Vector3.Lerp(transform.position, m_moveTarget.position, time / maxTime);
	}
}