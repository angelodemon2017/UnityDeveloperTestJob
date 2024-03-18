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
        private Tower _focusTower;

        public void SelectedTower(Tower focusTower)
        {
            _focusTower = focusTower;
        }

        public void OnBuildTower(TowerType towerType)
        {
            _focusTower.SelectType(towerType);
        }

        public void Upgrade()
        {
            _focusTower.Upgrade();
        }

        public Tower InitTower()
        {
            Tower newTower = new();
            Towers.Add(newTower);
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