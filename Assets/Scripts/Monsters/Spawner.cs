using Monstrs;
using TimerController;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private float _spawnInterval = 3;

	[SerializeField] private Monster monsterPrefab;
	[SerializeField] private Transform _spawnPosition;
	[SerializeField] private Transform _moveTarget;

	private float _spawnTimer = 0;

	void Update()
	{
		RunTimer();
	}

	private void RunTimer()
	{
		_spawnTimer = Timer.Run(_spawnTimer, _spawnInterval, Spawn);
	}

	private void Spawn()
	{
		var newMonster = Instantiate(monsterPrefab, _spawnPosition.position, Quaternion.identity, transform);
		newMonster.Init(_moveTarget);
		MonstersController.Instance.AddMonster(newMonster);
	}
}