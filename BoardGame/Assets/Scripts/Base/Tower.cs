using DG.Tweening;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Gun Parameters")]
    [SerializeField]
    private float damage;
    [SerializeField]
    private float shootTime;

    [Header("Selection")]
    [SerializeField]
    private int activeTileSortingOrder;
    [SerializeField]
    private int deactiveTileSortingOrder;

    [Header("Tower Level")]
    [SerializeField]
    private int level;
    [SerializeField]
    private int maxLevel = 4;

    [Header("Tower Type")]
    [SerializeField]
    private TowerType type;

    [Header("References")]
    private SpriteRenderer spriteRendererComponent;
    private Gun towerGun;
    protected Tile towerTile;

    private void Awake()
    {
        spriteRendererComponent = GetComponentInChildren<SpriteRenderer>();
        towerGun = GetComponentInChildren<Gun>();
    }

    private void Start()
    {
        Sequence startSequence = DOTween.Sequence();
        startSequence.Append(transform.DOScale(1f, TimeManager.GetUIDelay()));
        startSequence.Append(transform.DOScale(1.5f, TimeManager.GetUIDelay()));
        startSequence.Append(transform.DOScale(1f, TimeManager.GetUIDelay()).SetEase(Ease.Flash));

        AddTowerToList();
        UpdateTower();
    }

    protected virtual void AddTowerToList()
    {
    }

    public void UpdateTower()
    {
        SetDamageAndSpeed();
    }

    private void SetDamageAndSpeed()
    {
        SetDamage();
        SetShootTime();
    }

    public void SetDamage()
    {
        //Debug.Log("Damage Setted!");
        towerGun.SetDamage(damage);
    }

    public void SetShootTime()
    {
        //Debug.Log("ShootTime Setted!");
        towerGun.SetShootTime(shootTime);
    }

    /// <summary>
    /// Sets the sorting order of the sprite renderer component to the active tile sorting order.
    /// </summary>
    public void Select()
    {
        spriteRendererComponent.sortingOrder = activeTileSortingOrder;
    }

    /// <summary>
    /// Sets the sorting order of the sprite renderer component to the deactive tile sorting order.
    /// </summary>
    public void Deselect()
    {
        spriteRendererComponent.sortingOrder = deactiveTileSortingOrder;
    }

    /// <summary>
    /// Returns the level of the tower
    /// </summary>
    /// <returns></returns>
    public int GetTowerLevel()
    {
        return level;
    }

    /// <summary>
    /// It checks if the tower is at its maximum
    /// </summary>
    /// <returns></returns>
    public bool IsMax()
    {
        return level >= maxLevel;
    }

    /// <summary>
    /// Returns the type of the tower
    /// </summary>
    /// <returns></returns>
    public TowerType GetTowerType()
    {
        return type;
    }

    /// <summary>
    /// Sets the parent transform of the entity and resets its position
    /// </summary>
    /// <param name="parentTransform"></param>
    public void SetParent(Transform parentTransform)
    {
        transform.parent = parentTransform;
        towerTile = GetComponentInParent<Tile>();
        ResetPosition();
    }

    /// <summary>
    /// Resets the position of the entity to its initial position
    /// </summary>
    public void ResetPosition()
    {
        transform.DOLocalMove(Vector3.zero, TimeManager.GetUIDelay());
    }

    /// <summary>
    /// Returns the sprite associated with the sprite renderer component.
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
    {
        return spriteRendererComponent.sprite;
    }

    public virtual void Deactive()
    {
    }

    public Tile GetTile()
    {
        return towerTile;
    }
}
