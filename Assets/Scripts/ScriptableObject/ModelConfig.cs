using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Towers;

[CreateAssetMenu(fileName = "ModelConfig", menuName = "Configs/Model Configuration")]
public class ModelConfig : ScriptableObject
{
    [Header("Base Towers")]
    public List<TowerFundament> fundamentTowerModels;

    [Header("Weapons Tower")]
    public List<TowerBase> weaponTowerModels;

    [Header("Windows")]
    public List<BaseWindow> windows;

    public TowerFundament GetFundamentTowerModel(int level)
    {
        if (fundamentTowerModels.Count > level)
        {
            return fundamentTowerModels[level];
        }
        else
        {
            return fundamentTowerModels.LastOrDefault();
        }
    }

    public TowerBase GetWeaponTowerModel(TowerType tower, int level)
    {
        var towersByType = weaponTowerModels.Where(x => x.TowerType == tower).ToList();
        if (towersByType.Count > level)
        {
            return towersByType[level];
        }
        else
        {
            return towersByType.LastOrDefault();
        }
    }

    public BaseWindow GetWindow(Windows window)
    {
        return windows.FirstOrDefault(w => w.WindowType == window);
    }
}