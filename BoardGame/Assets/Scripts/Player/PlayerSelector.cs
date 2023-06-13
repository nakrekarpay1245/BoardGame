using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoSingleton<PlayerSelector>
{
    private const float minimumSelectionDistance = 0.75f;

    private Tile firstTile = null;
    private Tile lastTile = null;

    [Header("Tower")]
    [SerializeField]
    private List<Tower> primitiveTowerPrefabList = null;
    private Tower currentTower = null;

    private int randomTileCallCount;

    private Touch touch;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                SelectFirstTileTower();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                MoveCurrentTower();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (currentTower)
                {
                    if (!currentTower.IsMax())
                    {
                        SelectLastTile();
                        if (lastTile && firstTile && currentTower)
                        {
                            HandleTowerPlacement();
                        }
                        firstTile = null;
                        lastTile = null;
                        currentTower = null;
                    }
                    else
                    {
                        lastTile = null;
                        currentTower?.ResetPosition();
                        return;
                    }
                }
            }
        }
        else
        {
            currentTower?.ResetPosition();
        }
    }

    /// <summary>
    /// </summary>
    private void SelectFirstTileTower()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < PlayerTileManager.singleton.GetActiveTileList().Count; i++)
        {
            Tile tile = PlayerTileManager.singleton.GetActiveTileList()[i];
            float distance = Vector2.Distance(tile.transform.position, touchPosition);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                firstTile = tile;
            }
        }

        if (nearestDistance > minimumSelectionDistance)
        {
            firstTile = null;
            return;
        }

        currentTower = firstTile.GetTower();
        currentTower?.Select();
    }

    /// <summary>
    /// </summary>
    private void MoveCurrentTower()
    {
        if (currentTower)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 entityPosition = new Vector3(touchPosition.x, touchPosition.y, 0);
            currentTower.transform.position = entityPosition;
        }
    }

    /// <summary>
    /// </summary>
    private void SelectLastTile()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < PlayerTileManager.singleton.GetActiveTileList().Count; i++)
        {
            Tile tile = PlayerTileManager.singleton.GetActiveTileList()[i];
            float distance = Vector2.Distance(tile.transform.position, touchPosition);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                lastTile = tile;
            }
        }

        if (nearestDistance > minimumSelectionDistance || firstTile == lastTile)
        {
            lastTile = null;
            currentTower?.ResetPosition();
            return;
        }
    }

    /// <summary>
    /// </summary>
    private void HandleTowerPlacement()
    {
        if (lastTile)
        {
            if (!lastTile.GetIsFull())
            {
                currentTower?.ResetPosition();

                AudioManager.singleton.PlaySound("ChangeSFX");
            }
            else
            {
                if (lastTile.GetTower().GetTowerType() == currentTower.GetTowerType())
                {
                    if (lastTile.GetTower().GetTowerLevel() == currentTower.GetTowerLevel())
                    {
                        firstTile.Clear();
                        lastTile.SetTower(currentTower);
                        currentTower.Deselect();
                        currentTower = null;

                        AudioManager.singleton.PlaySound("SparkleSFX");
                    }
                    else
                    {
                        currentTower?.ResetPosition();

                        AudioManager.singleton.PlaySound("ChangeSFX");
                    }
                }
                else
                {
                    currentTower?.ResetPosition();

                    AudioManager.singleton.PlaySound("ChangeSFX");
                }
            }
        }
    }


    /// <summary>
    /// This function generates an Entity object and places it on a randomly selected
    /// Tile object from the active Tile list. If there are no available Tile objects,
    /// the Entity object will not be generated.
    /// </summary>
    public void ProduceTower()
    {
        if (PlayerEconomyManager.singleton.CanProduce())
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

            ParticleManager2.singleton.PlayParticleAtPoint("PlacementParticle",
                randomTile.transform.position);

            AudioManager.singleton.PlaySound("PopSFX");
        }
    }

    public void UpgradeAirTower()
    {
        if (PlayerEconomyManager.singleton.CanUpgrade(TowerType.AIR))
        {
            PlayerTowerManager.singleton.UpgradeTower(TowerType.AIR);
        }
    }
    public void UpgradeFireTower()
    {
        if (PlayerEconomyManager.singleton.CanUpgrade(TowerType.FIRE))
        {
            PlayerTowerManager.singleton.UpgradeTower(TowerType.FIRE);
        }
    }
    public void UpgradeEarthTower()
    {
        if (PlayerEconomyManager.singleton.CanUpgrade(TowerType.EARTH))
        {
            PlayerTowerManager.singleton.UpgradeTower(TowerType.EARTH);
        }
    }
    public void UpgradeWaterTower()
    {
        if (PlayerEconomyManager.singleton.CanUpgrade(TowerType.WATER))
        {
            PlayerTowerManager.singleton.UpgradeTower(TowerType.WATER);
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
        if (randomTileCallCount < PlayerTileManager.singleton.GetActiveTileList().Count)
        {
            Tile randomTile = PlayerTileManager.singleton.GetActiveTileList()[Random.Range(0,
                PlayerTileManager.singleton.GetActiveTileList().Count)];

            if (randomTile.GetIsFull())
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