using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float stoppingDistance;
    [SerializeField]
    private List<Transform> patrolPointList;

    private Vector3 patrolPoint;
    private int patrolIndex = -1;

    private void Start()
    {
        SetTargetPosition();
        EnemyManager.singleton.AddEnemyToList(this);
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
            PlayerBase.singleton.DecreaseHealth();
            gameObject.SetActive(false);
            Debug.Log("Road finished!");
        }
    }

    public void SetPatrolPointList(List<Transform> patrolPointList)
    {
        this.patrolPointList = patrolPointList;
    }
}
