using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField]
    protected float maxHealth;
    private float currentHealth;

    private SpriteRenderer spriteRendererComponent;
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color hitColor;

    protected EnemyAI enemyAI;
    private void Awake()
    {
        spriteRendererComponent = GetComponentInChildren<SpriteRenderer>();
        enemyAI = GetComponent<EnemyAI>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();
        }
        else
        {
            HitEffect();
        }
    }

    protected virtual void Dead()
    {
        StopAllCoroutines();
        enemyAI.Dead();
    }

    private void HitEffect()
    {
        StopCoroutine(HitEffectRoutine());
        StartCoroutine(HitEffectRoutine());
    }

    private IEnumerator HitEffectRoutine()
    {
        spriteRendererComponent.color = hitColor;
        yield return new WaitForSeconds(TimeManager.GetUIDelay2());
        spriteRendererComponent.color = normalColor;
    }
}
