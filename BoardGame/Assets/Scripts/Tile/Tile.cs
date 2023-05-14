using DG.Tweening;
using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Tower currentTower;

    [Header("Tile Visualize")]
    [SerializeField]
    private Sprite emptyTileSprite;
    [SerializeField]
    private Sprite fullTileSprite;

    private SpriteRenderer spriteRenderer;

    private int towerLevel;
    private TowerType towerType;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetTower(GetComponentInChildren<Tower>());
    }

    private void Start()
    {
        transform.DOScale(0, 0);
        transform.DOScale(1, TimeManager.singleton.GetUIDelay()).SetEase(Ease.Flash);
        TileManager.singleton.AddTile(this);
    }

    /// <summary>
    /// </summary>
    /// <param name="tower"></param>
    public void SetTower(Tower tower)
    {
        if (tower)
        {
            if (currentTower)
            {
                currentTower.gameObject.SetActive(false);
                tower.gameObject.SetActive(false);

                Clear();

                Tower newTower =
                    Instantiate(TowerManager.singleton.GetNextTower(towerLevel, towerType),
                    transform.position, Quaternion.identity);

                currentTower = newTower;
                currentTower.SetParent(transform);
                towerLevel = currentTower.GetTowerLevel();
                towerType = currentTower.GetTowerType();
            }
            else
            {
                currentTower = tower;
                currentTower.SetParent(transform);
                towerLevel = currentTower.GetTowerLevel();
                towerType = currentTower.GetTowerType();
            }

            spriteRenderer.sprite = fullTileSprite;
            PopScale();
        }
    }

    /// <summary>
    /// This function pops the scale of the current transform by a small amount using DOTween's PunchScale method, 
    /// then resets the scale to 1 using DOTween's DOScale method.
    /// </summary>
    private void PopScale()
    {
        transform.DOPunchScale(Vector3.one * 0.1f, TimeManager.singleton.GetUIDelay2()).OnComplete(() =>
        {
            transform.DOScale(1, 0);
        });
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public Tower GetTower()
    {
        return currentTower;
    }

    /// <summary>
    /// This function clears the current entity on the tile, making it empty, and sets the tile
    /// sprite to the emptyTileSprite
    /// </summary>
    public void Clear()
    {
        currentTower = null;
        spriteRenderer.sprite = emptyTileSprite;
    }

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public bool GetIsFull()
    {
        return currentTower;
    }
}
