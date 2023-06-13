using TMPro;
using UnityEngine;

public class OppositeBase : MonoSingleton<OppositeBase>
{
    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI healthText;

    [Header("Player Health")]
    [SerializeField]
    private int maxHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        DisplayHealth();
    }

    public void DecreaseHealth()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dead();
        }
        DisplayHealth();
    }

    public void Dead()
    {
        LevelManager.singleton.FinishLevel(true);
    }

    public void IncreaseHealth()
    {
        currentHealth++;
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.text = currentHealth.ToString();
    }
}
