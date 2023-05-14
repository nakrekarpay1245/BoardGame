using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Enemy Parameters")]
    [SerializeField]
    private List<Transform> patrolPointList;

    [Header("Enemy Generate Parameters")]
    [SerializeField]
    private float generateTime = 0.5f;
    private float nextGenerateTime;

    [SerializeField]
    private EnemyMovement enemyPrefab;

    private void Update()
    {
        if(Time.time > nextGenerateTime)
        {
            nextGenerateTime = Time.time + generateTime;
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        EnemyMovement generatedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        generatedEnemy.SetPatrolPointList(patrolPointList);
    }
}
