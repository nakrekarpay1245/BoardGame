using UnityEngine;

public class OppositeEconomyManager : MonoSingleton<OppositeEconomyManager>
{
    [Header("Tower Parameters")]
    [SerializeField]
    private float towerPrice;

    [Header("Coin Parameters")]
    [SerializeField]
    private float coinCount;

    [Header("Control Parameters")]
    [SerializeField]
    private float controlTime = 5;

    private void Start()
    {
        InvokeRepeating(nameof(ControlCoin), controlTime, controlTime);
    }

    private void ControlCoin()
    {
        if (coinCount >= towerPrice)
        {
            OppositeSelector.singleton.ProduceTower();
        }
    }

    public void IncreaseCoin(float value)
    {
        coinCount += value;
    }

    public void DecreaseCoin()
    {
        coinCount -= towerPrice;
    }

    public bool CanProduce()
    {
        if (coinCount >= towerPrice)
        {
            DecreaseCoin();
            towerPrice += 10;

            return true;
        }

        return false;
    }
}
