using UnityEngine;
using UnityEngine.AI;

public class EnemyIdleState : IState
{
    // Hareket
    private float moveSpeed;

    // Component
    private EnemyAI enemyAI;

    // Konum
    private Transform ownTransform;
    private Transform playerTransform;

    // Algýlama
    private float chaseRadius;

    // Bekleme
    private float idleWaitTime;
    private float timer;

    public EnemyIdleState(IdleStateData idleStateData, EnemyAI enemyAI)
    {
        this.moveSpeed = idleStateData.moveSpeed;
        this.chaseRadius = idleStateData.chaseRadius;
        this.enemyAI = enemyAI;
        this.ownTransform = enemyAI.ownTransform;
        this.idleWaitTime = idleStateData.waitTime;
    }

    public void OnStateEnter()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Enter Idle State");
        timer = 0;
        SetStateSpeed();
        SetAnimatorVariable();
    }

    public void OnStateExit()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Exit Idle State");
    }

    public void OnStateUpdate()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Update Idle State");
    }

    private void SetStateSpeed()
    {
        //navMeshAgent.speed = moveSpeed;
    }

    private void SetAnimatorVariable()
    {
        //animator.SetBool("isWalk", false);
    }
}
