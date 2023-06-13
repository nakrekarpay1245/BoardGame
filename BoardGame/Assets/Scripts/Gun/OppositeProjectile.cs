public class OppositeProjectile : Projectile
{
    protected override void DamageToTarget()
    {
        gameObject.SetActive(false);
        EnemyHealth enemyHealth = null;
        target.gameObject.TryGetComponent<EnemyHealth>(out enemyHealth);
        enemyHealth.TakeDamage(damage);
    }
}
