using UnityEngine;

public class OppositeTower : Tower
{
    protected override void AddTowerToList()
    {
        OppositeTowerManager.singleton.AddTower(this);
    }

    public override void Deactive()
    {
        OppositeTowerManager.singleton.RemoveTower(this);
        gameObject.SetActive(false);
    }
}
