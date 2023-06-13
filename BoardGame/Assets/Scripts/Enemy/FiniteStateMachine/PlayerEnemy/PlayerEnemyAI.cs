using UnityEngine;

public class PlayerEnemyAI : EnemyAI
{
    protected override void AddEnemyToList()
    {
        base.AddEnemyToList();
        PlayerEnemyManager.singleton.AddEnemyToList(this);
    }

    public override void AttackToBase()
    {
        base.AttackToBase();
        PlayerBase.singleton.DecreaseHealth();
    }

    public override void IncreaseManagerCoin()
    {
        base.IncreaseManagerCoin();
        PlayerEconomyManager.singleton.IncreaseCoin(5);
    }

    protected override void RemoveEnemyFromList()
    {
        base.RemoveEnemyFromList();
        PlayerEnemyManager.singleton.RemoveEnemyFromList(this);
    }
}
