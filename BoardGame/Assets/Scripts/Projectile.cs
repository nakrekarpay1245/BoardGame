using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Damage Parameters")]
    [SerializeField]
    private int damage = 1;

    [Header("Movement Parameters")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float stoppingDistance;

    private Transform target;
    private Vector3 targetPosition;

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
            EnemyHealth enemyHealth = null;
            target.gameObject.TryGetComponent<EnemyHealth>(out enemyHealth);
            enemyHealth.TakeDamage(damage);
        }
    }

    public void SetTarget(Transform targetTransform)
    {
        target = targetTransform;
        targetPosition = targetTransform.position;
    }
}
