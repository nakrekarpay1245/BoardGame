using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoSingleton<TowerManager>
{
    [Header("Towers")]
    [Header("AIR")]
    [SerializeField]
    private List<Tower> airTowerList;
    [Header("FIRE")]
    [SerializeField]
    private List<Tower> fireTowerList;
    [Header("SOIL")]
    [SerializeField]
    private List<Tower> soilTowerList;
    [Header("WATER")]
    [SerializeField]
    private List<Tower> waterTowerList;

    public Tower GetNextTower(int index, TowerType type)
    {
        switch (type)
        {
            case TowerType.AIR:
                return airTowerList[index];

            case TowerType.FIRE:
                return fireTowerList[index];

            case TowerType.SOIL:
                return soilTowerList[index];

            case TowerType.WATER:
                return waterTowerList[index];

            default:
                return null;
        }
    }
}
