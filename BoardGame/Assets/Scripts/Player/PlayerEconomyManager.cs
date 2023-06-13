using TMPro;
using UnityEngine;

public class PlayerEconomyManager : MonoSingleton<PlayerEconomyManager>
{
    [Header("Upgrade Tower")]
    [Header("Air Parameters")]
    [SerializeField]
    private int airTowerUpgradePrice;
    [SerializeField]
    private TextMeshProUGUI airTowerUpgradePriceText;

    [Header("Fire Parameters")]
    [SerializeField]
    private int fireTowerUpgradePrice;
    [SerializeField]
    private TextMeshProUGUI fireTowerUpgradePriceText;

    [Header("Earth Parameters")]
    [SerializeField]
    private int earthTowerUpgradePrice;
    [SerializeField]
    private TextMeshProUGUI earthTowerUpgradePriceText;

    [Header("Water Parameters")]
    [SerializeField]
    private int waterTowerUpgradePrice;
    [SerializeField]
    private TextMeshProUGUI waterTowerUpgradePriceText;

    [Space]

    [Header("Produce Tower")]
    [Header("Tower Parameters")]
    [SerializeField]
    private int towerPrice;
    [SerializeField]
    private TextMeshProUGUI towerPriceText;

    [Header("Coin Parameters")]
    [SerializeField]
    private float coinCount;

    [SerializeField]
    private TextMeshProUGUI coinCountText;

    private void Awake()
    {
        DisplayCoinCount();
        DisplayTowerPrice();
        DisplayAirTowerUpgradePrice();
        DisplayFireTowerUpgradePrice();
        DisplayEarthTowerUpgradePrice();
        DisplayWaterTowerUpgradePrice();
    }

    public void IncreaseCoin(float value)
    {
        coinCount += value;
        DisplayCoinCount();
    }

    public void DecreaseCoin(int value)
    {
        coinCount -= value;
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
            DecreaseCoin(towerPrice);

            DisplayTowerPrice();
            return true;
        }

        return false;
    }

    private void DisplayTowerPrice()
    {
        towerPrice += 10;
        towerPriceText.text = towerPrice.ToString();
    }

    public bool CanUpgrade(TowerType towerType)
    {
        switch (towerType)
        {
            case TowerType.AIR:
                if (coinCount >= airTowerUpgradePrice)
                {
                    DecreaseCoin(airTowerUpgradePrice);

                    DisplayAirTowerUpgradePrice();
                    return true;
                }
                return false;

            case TowerType.FIRE:
                if (coinCount >= fireTowerUpgradePrice)
                {
                    DecreaseCoin(fireTowerUpgradePrice);

                    DisplayFireTowerUpgradePrice();
                    return true;
                }
                return false;

            case TowerType.EARTH:
                if (coinCount >= earthTowerUpgradePrice)
                {
                    DecreaseCoin(earthTowerUpgradePrice);

                    DisplayEarthTowerUpgradePrice();
                    return true;
                }
                return false;

            case TowerType.WATER:
                if (coinCount >= waterTowerUpgradePrice)
                {
                    DecreaseCoin(waterTowerUpgradePrice);

                    DisplayWaterTowerUpgradePrice();
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

    private void DisplayAirTowerUpgradePrice()
    {
        airTowerUpgradePrice *= 2;
        airTowerUpgradePriceText.text = airTowerUpgradePrice.ToString();
    }
    private void DisplayFireTowerUpgradePrice()
    {
        fireTowerUpgradePrice *= 2;
        fireTowerUpgradePriceText.text = fireTowerUpgradePrice.ToString();
    }
    private void DisplayEarthTowerUpgradePrice()
    {
        earthTowerUpgradePrice *= 2;
        earthTowerUpgradePriceText.text = earthTowerUpgradePrice.ToString();
    }
    private void DisplayWaterTowerUpgradePrice()
    {
        waterTowerUpgradePrice *= 2;
        waterTowerUpgradePriceText.text = waterTowerUpgradePrice.ToString();
    }
}

