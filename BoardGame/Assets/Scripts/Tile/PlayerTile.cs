using UnityEngine;

public class PlayerTile : Tile
{
    protected override void AddTileToList()
    {
        PlayerTileManager.singleton.AddTile(this);
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

                Tower newTower = Instantiate(PlayerTowerManager.singleton.GetNextTower(towerLevel,
                    towerType), transform.position, Quaternion.identity);

                currentTower = newTower;
                currentTower.SetParent(transform);
                towerLevel = currentTower.GetTowerLevel();
                towerType = currentTower.GetTowerType();

                ParticleManager2.singleton.PlayParticleAtPoint("CombineParticle",
                    transform.position + (Vector3.down / 4));
            }
            else
            {
                currentTower = tower;
                currentTower.SetParent(transform);
                towerLevel = currentTower.GetTowerLevel();
                towerType = currentTower.GetTowerType();
            }

            //spriteRenderer.sprite = fullTileSprite;
            PopScale();
        }
    }
}
