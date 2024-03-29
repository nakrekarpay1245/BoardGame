using DG.Tweening;
using UnityEngine;

public class Tile : MonoBehaviour
{
    protected Tower currentTower;
    public Tower Tower => currentTower;

    protected int towerLevel;
    protected TowerType towerType;
    public bool IsFull => currentTower;

    private void Awake()
    {
        SetTower(GetComponentInChildren<Tower>());
    }

    private void Start()
    {
        transform.DOScale(0, 0);
        transform.DOScale(1, TimeManager.GetUIDelay()).SetEase(Ease.Flash);
        AddTileToList();
    }

    protected virtual void AddTileToList()
    {
    }

    /// <summary>
    /// </summary>
    /// <param name="tower"></param>
    public virtual void SetTower(Tower tower)
    {
    }

    /// <summary>
    /// This function pops the scale of the current transform by a small amount using DOTween's PunchScale method, 
    /// then resets the scale to 1 using DOTween's DOScale method.
    /// </summary>
    protected void PopScale()
    {
        transform.DOPunchScale(Vector3.one * 0.1f, TimeManager.GetUIDelay2()).OnComplete(() =>
        {
            transform.DOScale(1, 0);
        });
    }

    /// <summary>
    /// This function clears the current entity on the tile, making it empty, and sets the tile
    /// sprite to the emptyTileSprite
    /// </summary>
    public void Clear()
    {
        currentTower = null;
    }
}