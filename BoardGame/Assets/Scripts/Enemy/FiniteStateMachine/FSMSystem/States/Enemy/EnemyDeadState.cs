using UnityEngine;

public class EnemyDeadState : IState
{
    // Component
    private EnemyAI enemyAI;

    public EnemyDeadState(DeadStateData deadStateData, EnemyAI enemyAI)
    {
        this.enemyAI = enemyAI;
    }

    public void OnStateEnter()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Enter Dead State");
        enemyAI.DestroyEnemy();
        enemyAI.IncreaseManagerCoin();
    }


    public void OnStateExit()
    {
        Debug.Log("Dead State Exit");
    }

    public void OnStateUpdate()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Update Dead State");
    }
}