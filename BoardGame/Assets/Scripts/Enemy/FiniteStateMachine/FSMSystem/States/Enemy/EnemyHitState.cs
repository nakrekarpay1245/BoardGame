using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHitState : IState
{
    // Hareket
    private float moveSpeed;
    private float rotateSpeed;

    // Component
    private EnemyAI enemyAI;

    // Konum
    private Transform ownTransform;

    // Algýlama
    private float chaseRadius;

    // Bekleme
    private float hitWaitTime;
    private float timer;

    public EnemyHitState(HitStateData hitStateData, EnemyAI enemyAI)
    {
        this.moveSpeed = hitStateData.moveSpeed;
        this.rotateSpeed = hitStateData.rotateSpeed;
        this.chaseRadius = hitStateData.chaseRadius;
        this.enemyAI = enemyAI;
        this.ownTransform = enemyAI.ownTransform;
        this.hitWaitTime = hitStateData.waitTime;
    }

    public void OnStateEnter()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Enter Hit State");
        timer = 0;
        SetStateSpeed();
        SetAnimatorVariable();
    }

    public void OnStateExit()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Exit Hit State");
    }

    public void OnStateUpdate()
    {
        Debug.Log(enemyAI.gameObject.name + " Enemy Update Hit State");
    }

    private void SetStateSpeed()
    {
    }

    private void SetAnimatorVariable()
    {
    }
}
