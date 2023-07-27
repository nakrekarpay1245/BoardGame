using System.Collections.Generic;
using UnityEngine;

public class OppositeSelector : MonoSingleton<OppositeSelector>
{
    [Header("Tower")]
    [SerializeField]
    private List<Tower> primitiveTowerPrefabList = null;

    private int randomTileCallCount;

    /// <summary>
    /// This function generates an Entity object and places it on a randomly selected
    /// Tile object from the active Tile list. If there are no available Tile objects,
    /// the Entity object will not be generated.
    /// </summary>
    public void ProduceTower()
    {
        if (OppositeEconomyManager.singleton.CanProduce())
        {
            randomTileCallCount = 0;

            Tile randomTile = GetRandomTile();
            if (!randomTile)
            {
                return;
            }

            int randomPrimitiveTowerIndex = Random.Range(0, primitiveTowerPrefabList.Count);
            Tower primitiveTowerPrefab = primitiveTowerPrefabList[randomPrimitiveTowerIndex];

            Tower generatedTower = randomTile ? Instantiate(primitiveTowerPrefab,
                randomTile.transform.position, Quaternion.identity, randomTile.transform) : null;

            randomTile?.SetTower(generatedTower);

            ParticleManager.singleton.PlayParticleAtPoint("PlacementParticle",
                randomTile.transform.position);

            AudioManager.singleton.PlaySound("PopSFX");
        }
    }

    /// <summary>
    /// Returns a random empty Tile object. If the selected Tile is full,
    /// the function tries to select a different Tile by recursively calling itself. 
    /// If all Tiles are full, it returns a null value
    /// </summary>
    /// <returns></returns>
    private Tile GetRandomTile()
    {
        if (randomTileCallCount < OppositeTileManager.singleton.GetActiveTileList().Count)
        {
            Tile randomTile = OppositeTileManager.singleton.GetActiveTileList()[Random.Range(0,
                OppositeTileManager.singleton.GetActiveTileList().Count)];

            if (randomTile.IsFull)
            {
                randomTileCallCount++;
                return GetRandomTile();
            }
            randomTileCallCount++;
            return randomTile;
        }
        randomTileCallCount++;
        return null;
    }
}
