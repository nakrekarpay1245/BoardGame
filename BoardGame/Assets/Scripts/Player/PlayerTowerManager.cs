using System.Collections.Generic;
using UnityEngine;

public class PlayerTowerManager : MonoSingleton<PlayerTowerManager>
{
    [Header("Tower Types")]
    [Header("AIR")]
    [SerializeField]
    private List<Tower> airTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedAirTowerList;
    private int airTowerUpgradeLevel = 1;

    [Space]

    [Header("FIRE")]
    [SerializeField]
    private List<Tower> fireTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedFireTowerList;
    private int fireTowerUpgradeLevel = 1;

    [Space]

    [Header("EARTH")]
    [SerializeField]
    private List<Tower> earthTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedEarthTowerList;
    private int earthTowerUpgradeLevel = 1;

    [Space]

    [Header("WATER")]
    [SerializeField]
    private List<Tower> waterTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedWaterTowerList;
    private int waterTowerUpgradeLevel = 1;

    public void AddTower(Tower tower)
    {
        TowerType type = tower.GetTowerType();

        switch (type)
        {
            case TowerType.AIR:
                AddAirTowerToList(tower);
                break;

            case TowerType.FIRE:
                AddFireTowerToList(tower);
                break;

            case TowerType.EARTH:
                AddEarthTowerToList(tower);
                break;

            case TowerType.WATER:
                AddWaterTowerToList(tower);
                break;

            default:
                break;
        }
    }

    public void RemoveTower(Tower tower)
    {
        TowerType type = tower.GetTowerType();

        switch (type)
        {
            case TowerType.AIR:
                RemoveAirTowerFromList(tower);
                break;

            case TowerType.FIRE:
                RemoveFireTowerFromList(tower);
                break;

            case TowerType.EARTH:
                RemoveEarthTowerFromList(tower);
                break;

            case TowerType.WATER:
                RemoveWaterTowerFromList(tower);
                break;

            default:
                break;
        }
    }

    private void AddAirTowerToList(Tower tower)
    {
        if (!generatedAirTowerList.Contains(tower))
        {
            generatedAirTowerList.Add(tower);
        }
    }
    private void RemoveAirTowerFromList(Tower tower)
    {
        if (generatedAirTowerList.Contains(tower))
        {
            generatedAirTowerList.Remove(tower);
        }
    }

    private void AddFireTowerToList(Tower tower)
    {
        if (!generatedFireTowerList.Contains(tower))
        {
            generatedFireTowerList.Add(tower);
        }
    }
    private void RemoveFireTowerFromList(Tower tower)
    {
        if (generatedFireTowerList.Contains(tower))
        {
            generatedFireTowerList.Remove(tower);
        }
    }

    private void AddEarthTowerToList(Tower tower)
    {
        if (!generatedEarthTowerList.Contains(tower))
        {
            generatedEarthTowerList.Add(tower);
        }
    }
    private void RemoveEarthTowerFromList(Tower tower)
    {
        if (generatedEarthTowerList.Contains(tower))
        {
            generatedEarthTowerList.Remove(tower);
        }
    }

    private void AddWaterTowerToList(Tower tower)
    {
        if (!generatedWaterTowerList.Contains(tower))
        {
            generatedWaterTowerList.Add(tower);
        }
    }
    private void RemoveWaterTowerFromList(Tower tower)
    {
        if (generatedWaterTowerList.Contains(tower))
        {
            generatedWaterTowerList.Remove(tower);
        }
    }

    public Tower GetNextTower(int index, TowerType type)
    {
        switch (type)
        {
            case TowerType.AIR:
                return airTowerPrefabList[index];

            case TowerType.FIRE:
                return fireTowerPrefabList[index];

            case TowerType.EARTH:
                return earthTowerPrefabList[index];

            case TowerType.WATER:
                return waterTowerPrefabList[index];

            default:
                return null;
        }
    }

    public void UpgradeTower(TowerType type)
    {
        switch (type)
        {
            case TowerType.AIR:
                UpgradeAllAirTower();
                break;

            case TowerType.FIRE:
                UpgradeAllFireTower();
                break;

            case TowerType.EARTH:
                UpgradeAllEarthTower();
                break;

            case TowerType.WATER:
                UpgradeAllWaterTower();
                break;

            default:
                break;
        }
    }

    private void UpgradeAllAirTower()
    {
        airTowerUpgradeLevel++;
        UpdateAllAirTowers();
    }

    private void UpdateAllAirTowers()
    {
        for (int i = 0; i < generatedAirTowerList.Count; i++)
        {
            generatedAirTowerList[i].UpdateTower();
        }
    }

    private void UpgradeAllFireTower()
    {
        fireTowerUpgradeLevel++;
        UpdateAllFireTowers();
    }

    private void UpdateAllFireTowers()
    {
        for (int i = 0; i < generatedFireTowerList.Count; i++)
        {
            generatedFireTowerList[i].UpdateTower();
        }
    }

    private void UpgradeAllEarthTower()
    {
        earthTowerUpgradeLevel++;
        UpdateAllEarthTowers();
    }

    private void UpdateAllEarthTowers()
    {
        for (int i = 0; i < generatedEarthTowerList.Count; i++)
        {
            generatedEarthTowerList[i].UpdateTower();
        }
    }

    private void UpgradeAllWaterTower()
    {
        waterTowerUpgradeLevel++;
        UpdateAllWaterTowers();
    }

    private void UpdateAllWaterTowers()
    {
        for (int i = 0; i < generatedWaterTowerList.Count; i++)
        {
            generatedWaterTowerList[i].UpdateTower();
        }
    }

    public float GetUpgradeLevel(TowerType type)
    {
        switch (type)
        {
            case TowerType.AIR:
                return airTowerUpgradeLevel;

            case TowerType.FIRE:
                return fireTowerUpgradeLevel;

            case TowerType.EARTH:
                return earthTowerUpgradeLevel;

            case TowerType.WATER:
                return waterTowerUpgradeLevel;

            default:
                return 0;
        }
    }
}
