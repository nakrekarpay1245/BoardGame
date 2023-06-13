using UnityEngine;

public class PlayerGun : Gun
{
    protected override void Shoot()
    {
        EnemyAI closedEnemy = PlayerEnemyManager.singleton.GetClosedEnemy(transform.position);

        if (closedEnemy)
        {
            Projectile projectile =
                Instantiate(projectilePrefab, muzzleTransform.position, Quaternion.identity);

            projectile.SetTarget(closedEnemy.transform);
            projectile.SetDamage(damage);
        }
    }
}
