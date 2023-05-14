using DG.Tweening;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Selection")]
    [SerializeField]
    private int activeTileSortingOrder;
    [SerializeField]
    private int deactiveTileSortingOrder;

    [Header("Tower Level")]
    [SerializeField]
    private int level;

    [Header("Tower Type")]
    [SerializeField]
    private TowerType type;

    [Header("References")]
    [SerializeField]
    private SpriteRenderer spriteRendererComponent;

    private void Awake()
    {
        spriteRendererComponent = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        Sequence startSequence = DOTween.Sequence();
        startSequence.Append(transform.DOScale(0, 0));
        startSequence.Append(transform.DOScale(0, TimeManager.singleton.GetUIDelay()));
        startSequence.Append(transform.DOScale(1, TimeManager.singleton.GetUIDelay()).SetEase(Ease.Flash));
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
        ResetPosition();
    }

    /// <summary>
    /// Resets the position of the entity to its initial position
    /// </summary>
    public void ResetPosition()
    {
        transform.DOLocalMove(Vector3.zero, TimeManager.singleton.GetUIDelay());
    }

    /// <summary>
    /// Returns the sprite associated with the sprite renderer component.
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
    {
        return spriteRendererComponent.sprite;
    }
}
