public class PlayerTower : Tower
{
    protected override void AddTowerToList()
    {
        PlayerTowerManager.singleton.AddTower(this);
    }

    public override void Deactive()
    {
        PlayerTowerManager.singleton.RemoveTower(this);
        gameObject.SetActive(false);
    }
}
