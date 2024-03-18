using UnityEngine;

namespace Towers
{
    public class TowerPoint : MonoBehaviour
    {
        [SerializeField] private TowerType pointType;
        [SerializeField] private Transform _root;
        public Tower _tower;
        private TowerBase towerBase;
        public int indexTower;

        private void Awake()
        {
            var newT = TowersController.Instance.InitTower();
            _tower = newT.Item1;
            indexTower = newT.Item2;
            _tower.UpdateTower += UpdateTowerPoint;
        }

        private void UpdateTowerPoint()
        {
            pointType = _tower.TowerType;
            _root.DestroyChildrens();
            var fundament = Instantiate(StartUp.Instance.modelConfig.GetFundamentTowerModel(_tower.Level - 1), _root);

            towerBase = Instantiate(StartUp.Instance.modelConfig.GetWeaponTowerModel(pointType, _tower.Level - 1), fundament.GetPointWeapon);

            towerBase.Init(_tower, indexTower);
        }

        private void OnMouseDown()
        {
            TowersController.Instance.SelectedTower(_tower);
            WindowController.Instance.OpenWindow(
                pointType == TowerType.none 
                ? Windows.TowerBuild
                : Windows.SelectedTower);
        }
    }
}