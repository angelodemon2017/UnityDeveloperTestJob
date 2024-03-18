using System.Collections.Generic;
using Towers;
using UnityEngine;
using System.Linq;

namespace TowerConfig
{
    [CreateAssetMenu(fileName = "GameplayConfig", menuName = "Configs/Gameplay Configuration")]
    public class GameplayConfig : ScriptableObject
    {
        public List<TowerCannon> CannonTowers = new();
        public List<TowerMage> MageTowers = new();

        public TowerCharacteristic GetCharacteristic(TowerType Type, int level)
        {
            List<TowerCharacteristic> towers = new();
            switch (Type)
            {
                case TowerType.TowerCanon:
                    towers = CannonTowers.Cast<TowerCharacteristic>().ToList();
                    break;
                case TowerType.TowerMage:
                    towers = MageTowers.Cast<TowerCharacteristic>().ToList();
                    break;
            }

            if (towers.Count > level)
            {
                return towers[level];
            }
            else
            {
                return towers.LastOrDefault();
            }
        }
    }

    [System.Serializable]
    public class TowerCharacteristic
    {
        public TowerType Type;
        public int Power;
        public float Range;
    }

    [System.Serializable]
    public class TowerCannon : TowerCharacteristic
    {

    }

    [System.Serializable]
    public class TowerMage : TowerCharacteristic
    {

    }
}