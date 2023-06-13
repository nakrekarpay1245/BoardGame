public class OppositeEnemyAI : EnemyAI
{
    protected override void AddEnemyToList()
    {
        base.AddEnemyToList();
        OppositeEnemyManager.singleton.AddEnemyToList(this);
    }

    public override void AttackToBase()
    {
        base.AttackToBase();
        OppositeBase.singleton.DecreaseHealth();
    }

    public override void IncreaseManagerCoin()
    {
        base.IncreaseManagerCoin();
        OppositeEconomyManager.singleton.IncreaseCoin(5);
    }

    protected override void RemoveEnemyFromList()
    {
        base.RemoveEnemyFromList();
        OppositeEnemyManager.singleton.RemoveEnemyFromList(this);
    }
}
