using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Monstrs
{
    public class MonstersController : MonoBehaviour
    {
        public static MonstersController Instance;
        private List<Monster> _monsters = new();

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            for (int i = _monsters.Count - 1; i >= 0; i--)
            {
                _monsters[i].MoveTo();
            }
        }

        public void AddMonster(Monster monster)
        {
            monster.removeMonster += RemoveMonster;
            _monsters.Add(monster);
        }

        public void RemoveMonster(Monster monster)
        {
            monster.removeMonster -= RemoveMonster;
            _monsters.Remove(monster);
            Destroy(monster.gameObject);
        }

        public Monster GetNearMonster(Vector3 nearPosition, float distance)
        {
            if (_monsters.Count == 0)
            {
                return null;
            }

            return _monsters.FirstOrDefault(x => x.DistanceTo(nearPosition) < distance);
        }
    }
}