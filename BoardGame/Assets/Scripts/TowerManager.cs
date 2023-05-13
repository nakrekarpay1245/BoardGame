using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoSingleton<TowerManager>
{
    [Header("Entities")]
    [SerializeField]
    private List<Tower> towerList;

    public Tower GetTowerWithIndex(int index)
    {
        return towerList[index];
    }

    public int GetTowerListCount()
    {
        return towerList.Count;
    }
}
