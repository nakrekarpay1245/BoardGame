using UnityEngine;

public class OppositeGun : Gun
{
    protected override void Shoot()
    {
        EnemyAI closedEnemy = OppositeEnemyManager.singleton.GetClosedEnemy(transform.position);

        if (closedEnemy)
        {
            Projectile projectile =
                Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity);

            projectile.SetTarget(closedEnemy.transform);
            projectile.SetDamage(damage);
        }
    }
}
