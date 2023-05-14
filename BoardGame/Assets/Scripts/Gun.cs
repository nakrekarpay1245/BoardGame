using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Gun : MonoBehaviour
{
    [Header("Shoot Parameters")]
    [SerializeField]
    private float shootTime;
    private float nextShootTime;

    [SerializeField]
    private Transform muzzleTransform;

    [SerializeField]
    private Projectile projectilePrefab;

    private void Update()
    {
        if (Time.time > nextShootTime)
        {
            nextShootTime = Time.time + shootTime;
            Shoot();
        }
    }

    private void Shoot()
    {
        EnemyMovement closedEnemy = EnemyManager.singleton.GetClosedEnemy(transform.position);

        if (closedEnemy)
        {
            Projectile projectile =
                Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity);

            projectile.SetTarget(closedEnemy.transform);
        }
    }
}
