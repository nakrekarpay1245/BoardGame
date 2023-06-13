using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : IState
{
    // Hareket
    private float moveSpeed;

    // Component
    private EnemyAI enemyAI;

    // Konum
    private Transform ownTransform;

    // Saldýrý
    private float attackTime;
    private float attackTimer;

    // Bekleme
    private float attackWaitTime;
    private float waitTimer;

    public EnemyAttackState(AttackStateData attackStateData, EnemyAI enemyAI)
    {
        this.moveSpeed = attackStateData.moveSpeed;
        this.enemyAI = enemyAI;
        this.ownTransform = enemyAI.ownTransform;
        this.attackTime = attackStateData.attackTime;
        this.attackWaitTime = attackStateData.attackWaitTime;
    }

    public void OnStateEnter()
    {
        Debug.Log("Enter Attack State");
        waitTimer = 0;
        attackTimer = attackTime;
        SetStateSpeed();
        SetAnimatorVariable();
    }

    public void OnStateExit()
    {
        Debug.Log("Exit Attack State");
    }

    public void OnStateUpdate()
    {
        Debug.Log("Attack State Update");
    }

    private void SetStateSpeed()
    {
        //navMeshAgent.speed = moveSpeed;
    }
    private void SetAnimatorVariable()
    {
        //animator.SetBool("isWalk", false);
    }

    private void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > attackTime)
        {
            attackTimer = 0;
            //animator.applyRootMotion = true;
            //animator.CrossFade("ZombieAttack", 0.2f);
        }
    }
}
