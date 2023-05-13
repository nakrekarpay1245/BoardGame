using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoSingleton<Selector>
{
    private const float minimumSelectionDistance = 0.75f;

    private Tile firstTile = null;
    private Tile lastTile = null;

    [Header("Tower")]
    [SerializeField]
    private Tower primitiveTowerPrefab = null;
    private Tower currentTower = null;

    private int randomTileCallCount;

    [Header("Produce")]
    [SerializeField]
    private Image produceButtonFill;

    [Header("Auto Produce")]
    [SerializeField]
    private float autoProduceTime = 10;
    private float produceTimer;

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
                SelectLastTile();
                if (lastTile && firstTile && currentTower)
                {
                    HandleTowerPlacement();
                }
                firstTile = null;
                lastTile = null;
                currentTower = null;
            }
        }
        else
        {
            currentTower?.ResetPosition();
        }

        CalculateProduceTimer();
    }

    /// <summary>
    /// Calculates the produce timer and checks if it's time to produce a new entity
    /// </summary>
    private void CalculateProduceTimer()
    {
        if (produceTimer >= autoProduceTime)
        {
            produceTimer = 0;
            ProduceTower();
        }
        else
        {
            produceTimer += Time.deltaTime;
        }

        DisplayProduceTimer();
    }

    /// <summary>
    /// Decreases the produce timer by 1
    /// </summary>
    public void IncreaseProduceTimer()
    {
        produceTimer++;
    }

    /// <summary>
    /// Displays the produce timer by updating the fill amount of the produce button fill image.
    /// </summary>
    private void DisplayProduceTimer()
    {
        produceButtonFill.fillAmount = produceTimer / autoProduceTime;
    }

    /// <summary>
    /// </summary>
    private void SelectFirstTileTower()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < TileManager.singleton.GetActiveTileList().Count; i++)
        {
            Tile tile = TileManager.singleton.GetActiveTileList()[i];
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

        for (int i = 0; i < TileManager.singleton.GetActiveTileList().Count; i++)
        {
            Tile tile = TileManager.singleton.GetActiveTileList()[i];
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
                firstTile.Clear();
                lastTile.SetTower(currentTower);
                currentTower?.Deselect();
                currentTower = null;

                AudioManager.singleton.PlaySound("ChangeSFX");
            }
            else
            {
                if (lastTile.GetTower().GetEntityLevel() == currentTower.GetEntityLevel())
                {
                    firstTile.Clear();
                    lastTile.SetTower(currentTower);
                    currentTower.Deselect();
                    currentTower = null;

                    ParticleManager.singleton.PlayParticleAtPoint(lastTile.transform.position);

                    AudioManager.singleton.PlaySound("SparkleSFX");
                }
                else
                {
                    Tower firstTileEntity = firstTile.GetTower();

                    firstTile.Clear();
                    firstTile.SetTower(lastTile.GetTower());

                    lastTile.Clear();
                    lastTile.SetTower(firstTileEntity);
                    currentTower.Deselect();
                    currentTower = null;

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
        randomTileCallCount = 0;

        Tile randomTile = GetRandomTile();
        if (!randomTile)
        {
            return;
        }

        Tower generatedEntity = randomTile ?
            Instantiate(primitiveTowerPrefab, randomTile.transform) : null;
        randomTile?.SetTower(generatedEntity);

        ParticleManager.singleton.PlayParticleAtPoint(randomTile.transform.position);
        AudioManager.singleton.PlaySound("PopSFX");
    }

    /// <summary>
    /// Returns a random empty Tile object. If the selected Tile is full,
    /// the function tries to select a different Tile by recursively calling itself. 
    /// If all Tiles are full, it returns a null value
    /// </summary>
    /// <returns></returns>
    private Tile GetRandomTile()
    {
        if (randomTileCallCount < TileManager.singleton.GetActiveTileList().Count)
        {
            Tile randomTile = TileManager.singleton.GetActiveTileList()[Random.Range(0, TileManager.singleton.GetActiveTileList().Count)];
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