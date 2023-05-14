using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    private SpriteRenderer spriteRendererComponent;
    private void Awake()
    {
        spriteRendererComponent = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
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

    private void Dead()
    {
        EnemyManager.singleton.RemoveEnemyFromList(GetComponent<EnemyMovement>());
        EconomyManager.singleton.IncreaseCoin(maxHealth);
        gameObject.SetActive(false);
    }

    private void HitEffect()
    {
        StopCoroutine(HitEffectRoutine());
        StartCoroutine(HitEffectRoutine());
    }

    private IEnumerator HitEffectRoutine()
    {
        Color startColor = spriteRendererComponent.color;
        spriteRendererComponent.color = Color.white;
        yield return new WaitForSeconds(TimeManager.singleton.GetUIDelay2());
        spriteRendererComponent.color = startColor;
    }
}
