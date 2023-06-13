using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Damage Parameters")]
    [SerializeField]
    protected float damage = 1;

    [Header("Movement Parameters")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float stoppingDistance;

    protected Transform target;
    private Vector3 targetPosition;

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            MoveToTarget();
        }
        else
        {
            DamageToTarget();
        }
    }

    protected virtual void DamageToTarget()
    {      
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                        targetPosition, moveSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
        targetPosition = targetTransform.position;
    }

    public void SetDamage(float damageAmount)
    {
        damage = damageAmount;
    }
}
