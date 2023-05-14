using TMPro;
using UnityEngine;

public class PlayerBase : MonoSingleton<PlayerBase>
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
        DisplayHealth();
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
