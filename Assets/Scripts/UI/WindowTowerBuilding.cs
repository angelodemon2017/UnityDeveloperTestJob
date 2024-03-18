using System.Collections.Generic;
using Towers;
using UnityEngine;
using UnityEngine.UI;

public class WindowTowerBuilding : BaseWindow
{
    [SerializeField] private Button _buttonClose;
    [SerializeField] private Transform _parentListButtons;
    [SerializeField] private ButtonSelectTower _buttonSelectTowerPrefab;
    [SerializeField] private List<TowerType> _availableTypes;

    private void Awake()
    {
        _buttonClose.onClick.AddListener(CloseWindow);
        Init();
    }

    private void Init()
    {
        _parentListButtons.DestroyChildrens();

        foreach (var type in _availableTypes)
        {
            var newBut = Instantiate(_buttonSelectTowerPrefab, _parentListButtons);
            newBut.Init(type, SelectTower);
        }
    }

    private void SelectTower(TowerType pointType)
    {
        //¬ идеале дл€ окна нужно было описать модель и там уже подобную логику вызвать, а здесь оставить только работу с UI
        TowersController.Instance.OnBuildTower(pointType);
        WindowController.Instance.OpenWindow(Windows.SelectedTower);
    }

    private void CloseWindow()
    {
        WindowController.Instance.OpenWindow(Windows.MainWindow);
    }
}