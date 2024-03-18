using System;
using System.Collections.Generic;

namespace Towers
{
    public class TowersController
    {
        private static TowersController _instance;
        public static TowersController Instance 
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new();
                }
                return _instance;
            } 
        }

        private List<Tower> Towers = new();
        private int SelectTower;
        private Tower _focusTower;

        public void SelectedTower(Tower focusTower)
        {
            _focusTower = focusTower;
        }

        public void OnBuildTower(TowerType towerType)
        {
//            Towers[SelectTower].SelectType(towerType);
            _focusTower.SelectType(towerType);
        }

        public void Upgrade()
        {
//            Towers[SelectTower].Upgrade();
            _focusTower.Upgrade();
        }

        public (Tower, int) InitTower()
        {
            (Tower, int) newTower;
            newTower.Item1 = new();
            newTower.Item2 = Towers.Count;
            Towers.Add(newTower.Item1);
            return newTower;
        }
    }

    [System.Serializable]
    public class Tower
    {
        public TowerType TowerType;
        public int Level;
        public Action UpdateTower;

        public void SelectType(TowerType towerType)
        {
            TowerType = towerType;
            Level = 1;
            UpdateTower?.Invoke();
        }

        public void Upgrade()
        {
            Level++;
            UpdateTower?.Invoke();
        }
    }
}