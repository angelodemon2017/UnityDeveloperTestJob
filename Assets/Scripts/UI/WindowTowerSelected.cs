using Towers;
using UnityEngine;
using UnityEngine.UI;

public class WindowTowerSelected : BaseWindow
{
    [SerializeField] private Button _buttonUpgrade;
    [SerializeField] private Button _buttonClose;

    private void Awake()
    {
        _buttonUpgrade.onClick.AddListener(OnClickUpgrade);
        _buttonClose.onClick.AddListener(CloseWindow);
    }

    private void OnClickUpgrade()
    {
        TowersController.Instance.Upgrade();
    }

    private void CloseWindow()
    {
        WindowController.Instance.OpenWindow(Windows.MainWindow);
    }
}