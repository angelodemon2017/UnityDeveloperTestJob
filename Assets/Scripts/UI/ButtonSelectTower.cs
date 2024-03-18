using Towers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonSelectTower : MonoBehaviour
{
    [SerializeField] private TowerType _pointType;
    [SerializeField] private TextMeshProUGUI _label;
    private Action<TowerType> _clickAction;

    private void Awake()
    {
        UpdateUI();
        var but = GetComponent<Button>();
        but.onClick.AddListener(OnClick);
    }

    public void Init(TowerType pointType, Action<TowerType> clickAction)
    {
        _clickAction = clickAction;
        _pointType = pointType;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _label.text = _pointType.ToString();
    }

    private void OnClick()
    {
        //—юда ещЄ желательно вставить валидацию на проверку баланса
        _clickAction?.Invoke(_pointType);
    }
}