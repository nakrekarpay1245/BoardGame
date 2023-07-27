using UnityEngine;

public class OppositeTile : Tile
{
    protected override void AddTileToList()
    {
        OppositeTileManager.singleton.AddTile(this);
    }

    /// <summary>
    /// </summary>
    /// <param name="tower"></param>
    public override void SetTower(Tower tower)
    {
        if (tower)
        {
            if (currentTower)
            {
                currentTower.Deactive();
                tower.Deactive();

                Clear();

                Tower newTower = Instantiate(OppositeTowerManager.singleton.GetNextTower(towerLevel,
                    towerType), transform.position, Quaternion.identity);

                currentTower = newTower;
                currentTower.SetParent(transform);
                towerLevel = currentTower.TowerLevel;
                towerType = currentTower.TowerType;

                ParticleManager.singleton.PlayParticleAtPoint("CombineParticle",
                    transform.position + (Vector3.down / 4));
            }
            else
            {
                currentTower = tower;
                currentTower.SetParent(transform);
                towerLevel = currentTower.TowerLevel;
                towerType = currentTower.TowerType;
            }

            PopScale();
        }
    }
}
