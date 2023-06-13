using System.Collections.Generic;
using UnityEngine;

public class OppositeTowerManager : MonoSingleton<OppositeTowerManager>
{
    [Header("Control Parameters")]
    [SerializeField]
    private float controlTime = 5;

    [Space]

    [Header("Tower Types")]
    [Header("AIR")]
    [SerializeField]
    private List<Tower> airTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedAirTowerList;

    [Space]

    [Header("FIRE")]
    [SerializeField]
    private List<Tower> fireTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedFireTowerList;

    [Space]

    [Header("EARTH")]
    [SerializeField]
    private List<Tower> earthTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedEarthTowerList;

    [Space]

    [Header("WATER")]
    [SerializeField]
    private List<Tower> waterTowerPrefabList;
    [SerializeField]
    private List<Tower> generatedWaterTowerList;

    private void Start()
    {
        InvokeRepeating(nameof(ControlAllTowers), controlTime, controlTime);
    }

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

    private void ControlAllTowers()
    {
        ControlAirTowers();
        ControlEarthTowers();
        ControlFireTowers();
        ControlWaterTowers();
    }

    #region AIR
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

    private void ControlAirTowers()
    {
        for (int i = 0; i < generatedAirTowerList.Count; i++)
        {
            for (int j = 0; j < generatedAirTowerList.Count; j++)
            {
                if (i != j)
                {
                    Tower oppositeTowerI = generatedAirTowerList[i];
                    Tile oppositeTileI = oppositeTowerI.GetTile();
                    Tower oppositeTowerJ = generatedAirTowerList[j];
                    Tile oppositeTileJ = oppositeTowerJ.GetTile();

                    if (oppositeTowerI.GetTowerType() == oppositeTowerJ.GetTowerType())
                    {
                        if (oppositeTowerI.GetTowerLevel() == oppositeTowerJ.GetTowerLevel())
                        {
                            if (!oppositeTowerI.IsMax())
                            {
                                oppositeTileJ.SetTower(oppositeTowerI);
                                oppositeTileI.Clear();
                                oppositeTowerI.Deactive();
                                oppositeTowerJ.Deactive();
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region EARTH
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

    private void ControlEarthTowers()
    {
        for (int i = 0; i < generatedEarthTowerList.Count; i++)
        {
            for (int j = 0; j < generatedEarthTowerList.Count; j++)
            {
                if (i != j)
                {
                    Tower oppositeTowerI = generatedEarthTowerList[i];
                    Tile oppositeTileI = oppositeTowerI.GetTile();
                    Tower oppositeTowerJ = generatedEarthTowerList[j];
                    Tile oppositeTileJ = oppositeTowerJ.GetTile();

                    if (oppositeTowerI.GetTowerType() == oppositeTowerJ.GetTowerType())
                    {
                        if (oppositeTowerI.GetTowerLevel() == oppositeTowerJ.GetTowerLevel())
                        {
                            if (!oppositeTowerI.IsMax())
                            {
                                oppositeTileJ.SetTower(oppositeTowerI);
                                oppositeTileI.Clear();
                                oppositeTowerI.Deactive();
                                oppositeTowerJ.Deactive();
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region FIRE
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

    private void ControlFireTowers()
    {
        for (int i = 0; i < generatedFireTowerList.Count; i++)
        {
            for (int j = 0; j < generatedFireTowerList.Count; j++)
            {
                if (i != j)
                {
                    Tower oppositeTowerI = generatedFireTowerList[i];
                    Tile oppositeTileI = oppositeTowerI.GetTile();
                    Tower oppositeTowerJ = generatedFireTowerList[j];
                    Tile oppositeTileJ = oppositeTowerJ.GetTile();

                    if (oppositeTowerI.GetTowerType() == oppositeTowerJ.GetTowerType())
                    {
                        if (oppositeTowerI.GetTowerLevel() == oppositeTowerJ.GetTowerLevel())
                        {
                            if (!oppositeTowerI.IsMax())
                            {
                                oppositeTileJ.SetTower(oppositeTowerI);
                                oppositeTileI.Clear();
                                oppositeTowerI.Deactive();
                                oppositeTowerJ.Deactive();
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region WATER
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

    private void ControlWaterTowers()
    {
        for (int i = 0; i < generatedWaterTowerList.Count; i++)
        {
            for (int j = 0; j < generatedWaterTowerList.Count; j++)
            {
                if (i != j)
                {
                    Tower oppositeTowerI = generatedWaterTowerList[i];
                    Tile oppositeTileI = oppositeTowerI.GetTile();
                    Tower oppositeTowerJ = generatedWaterTowerList[j];
                    Tile oppositeTileJ = oppositeTowerJ.GetTile();

                    if (oppositeTowerI.GetTowerType() == oppositeTowerJ.GetTowerType())
                    {
                        if (oppositeTowerI.GetTowerLevel() == oppositeTowerJ.GetTowerLevel())
                        {
                            if (!oppositeTowerI.IsMax())
                            {
                                oppositeTileJ.SetTower(oppositeTowerI);
                                oppositeTileI.Clear();
                                oppositeTowerI.Deactive();
                                oppositeTowerJ.Deactive();
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion

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
}
