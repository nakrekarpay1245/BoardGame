using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    private float moveSpeed;
    private float stoppingDistance;

    public List<Transform> patrolPointList;

    private Vector3 patrolPoint;
    private int patrolIndex = -1;

    private EnemyAI enemyAI;

    private void Awake()
    {
        enemyAI = GetComponentInParent<EnemyAI>();
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetStoppingDistance(float distance)
    {
        stoppingDistance = distance;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, patrolPoint) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                patrolPoint, (moveSpeed / 10) * Time.deltaTime);
        }
        else
        {
            SetTargetPosition();
        }
    }

    private void SetTargetPosition()
    {
        patrolIndex++;
        if (patrolPointList.Count > patrolIndex)
        {
            patrolPoint = patrolPointList[patrolIndex].position;
        }
        else
        {
            enemyAI.AttackToBase();
            enemyAI.DestroyEnemy();
        }

        Vector3 targetDirection = patrolPoint - transform.position;
        targetDirection.z = 0;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void SetPatrolPointList(List<Transform> patrolPointList)
    {
        this.patrolPointList = patrolPointList;
        SetTargetPosition();
    }
}
