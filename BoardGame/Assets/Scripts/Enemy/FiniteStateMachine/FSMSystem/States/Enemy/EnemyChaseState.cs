using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : IState
{
    // Hareket
    private float moveSpeed;
    private float rotateSpeed;

    // Component
    private EnemyAI enemyAI;

    // Konum
    private Transform ownTransform;
    private Transform playerTransform;

    // Algýlama
    private float chaseRadius;
    private float attackRadius;

    private Vector2 velocity;
    private Vector3 smoothDeltaPosition;
    public EnemyChaseState(ChaseStateData chaseStateData, EnemyAI enemyAI)
    {
        this.moveSpeed = chaseStateData.moveSpeed;
        this.rotateSpeed = chaseStateData.rotateSpeed;
        this.chaseRadius = chaseStateData.chaseRadius;
        this.attackRadius = chaseStateData.attackRadius;
        this.enemyAI = enemyAI;
        this.ownTransform = enemyAI.ownTransform;
    }

    public void OnStateEnter()
    {
        Debug.Log(enemyAI.name + "Enemy Chase State Enter");

        SetStateSpeed();
        SetAnimatorVariable();
    }

    public void OnStateExit()
    {
        Debug.Log(enemyAI.name + "Enemy Exit Chase State");
    }

    public void OnStateUpdate()
    {
        Debug.Log(enemyAI.name + "Enemy Update Chase State");
    }

    private void SetStateSpeed()
    {
    }

    private void SetAnimatorVariable()
    {
    }
}
