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
    public int TowerLevel => level;
    [SerializeField]
    private int maxLevel = 4;
    public bool IsMax => level >= maxLevel;

    [Header("Tower Type")]
    [SerializeField]
    private TowerType type;
    public TowerType TowerType => type;

    private SpriteRenderer _spriteRendererComponent;
    private Gun _towerGun;
    protected Tile _towerTile;
    public Tile TowerTile => _towerTile;

    private void Awake()
    {
        _spriteRendererComponent = GetComponentInChildren<SpriteRenderer>();
        _towerGun = GetComponentInChildren<Gun>();
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
        _towerGun.SetDamage(damage);
    }

    public void SetShootTime()
    {
        //Debug.Log("ShootTime Setted!");
        _towerGun.SetShootTime(shootTime);
    }

    /// <summary>
    /// Sets the sorting order of the sprite renderer component to the active tile sorting order.
    /// </summary>
    public void Select()
    {
        _spriteRendererComponent.sortingOrder = activeTileSortingOrder;
    }

    /// <summary>
    /// Sets the sorting order of the sprite renderer component to the deactive tile sorting order.
    /// </summary>
    public void Deselect()
    {
        _spriteRendererComponent.sortingOrder = deactiveTileSortingOrder;
    }

    /// <summary>
    /// Sets the parent transform of the entity and resets its position
    /// </summary>
    /// <param name="parentTransform"></param>
    public void SetParent(Transform parentTransform)
    {
        transform.parent = parentTransform;
        _towerTile = GetComponentInParent<Tile>();
        ResetPosition();
    }

    /// <summary>
    /// Resets the position of the entity to its initial position
    /// </summary>
    public void ResetPosition()
    {
        transform.DOLocalMove(Vector3.zero, TimeManager.GetUIDelay());
    }

    public virtual void Deactive()
    {
    }
}