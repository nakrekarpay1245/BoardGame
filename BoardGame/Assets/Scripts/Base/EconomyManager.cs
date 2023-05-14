using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EconomyManager : MonoSingleton<EconomyManager>
{
    [Header("Tower Parameters")]
    [SerializeField]
    private int towerPrice;
    //[SerializeField]
    //private List<int> towerPriceList;
    [SerializeField]
    private int towerGenerateCount = 0;
    [SerializeField]
    private TextMeshProUGUI towerPriceText;

    [Header("Coin Parameters")]
    [SerializeField]
    private int coinCount;

    [SerializeField]
    private TextMeshProUGUI coinCountText;

    private void Awake()
    {
        DisplayCoinCount();
        DisplayTowerPrice();
    }

    public void IncreaseCoin(int value)
    {
        coinCount += value;
        DisplayCoinCount();
    }

    public void DecreaseCoin()
    {
        coinCount -= towerPrice;
        DisplayCoinCount();
    }

    private void DisplayCoinCount()
    {
        coinCountText.text = coinCount.ToString();
    }

    public bool CanProduce()
    {
        if (coinCount >= towerPrice)
        {
            DecreaseCoin();

            towerGenerateCount++;

            DisplayTowerPrice();
            return true;
        }

        return false;
    }

    private void DisplayTowerPrice()
    {
        towerPrice = Fibonacci(towerGenerateCount);
        towerPriceText.text = towerPrice.ToString();
    }

    private int Fibonacci(int n)
    {
        if (n <= 1)
            return n;

        int current = 1;
        int previous = 1;

        for (int i = 2; i < n; i++)
        {
            int temp = current;
            current += previous;
            previous = temp;
        }

        return current;
    }
}
