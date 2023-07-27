using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Shoot Parameters")]
    [SerializeField]
    private float shootTime;
    private float nextShootTime;
    [SerializeField]
    protected float damage;

    [SerializeField]
    protected Transform muzzleTransform;

    [SerializeField]
    protected Projectile projectilePrefab;

    private void Start()
    {
        nextShootTime = Time.time + shootTime;
    }

    private void Update()
    {
        if (Time.time > nextShootTime)
        {
            nextShootTime = Time.time + shootTime;
            Shoot();
        }
    }

    protected virtual void Shoot()
    {
    }

    public void SetDamage(float damageAmount)
    {
        //Debug.Log("Gun DA: " + damageAmount);
        damage = damageAmount;
    }

    public void SetShootTime(float shootTimeAmount)
    {
        //Debug.Log("Gun STA: " + shootTimeAmount);
        shootTime = shootTimeAmount;
    }
}