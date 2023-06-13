using UnityEngine;

public class EnemyLiveState : IState
{
    // Hareket
    private float moveSpeed;
    private float stoppingDistance;

    // Component
    private EnemyAI enemyAI;

    public EnemyLiveState(LiveStateData liveStateData, EnemyAI enemyAI)
    {
        this.moveSpeed = liveStateData.moveSpeed;
        this.stoppingDistance = liveStateData.stoppingDistance;
        this.enemyAI = enemyAI;
    }

    public void OnStateEnter()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Enter Live State");
        SetStateSpeed();
        SetStoppingDistance();
    }

    public void OnStateExit()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Exit Live State");
    }

    public void OnStateUpdate()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Update Live State");
    }

    private void SetStateSpeed()
    {
        enemyAI.SetSpeed(moveSpeed);
    }

    private void SetStoppingDistance()
    {
        enemyAI.SetStoppingDistance(stoppingDistance);
    }
}
