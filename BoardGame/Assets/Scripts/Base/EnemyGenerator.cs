using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Enemy Parameters")]
    [SerializeField]
    private List<Transform> patrolPointList;

    [Header("Enemy Generate Parameters")]
    [SerializeField]
    private float generateTime = 1f;
    [SerializeField]
    private float minimumGenerateTime = 0.1f;
    private float nextGenerateTime;

    [SerializeField]
    private EnemyAI enemyPrefab;
    [SerializeField]
    private Transform generatePoint;

    private void Start()
    {
        nextGenerateTime = Time.time + 1;
    }

    private void Update()
    {
        if (Time.time > nextGenerateTime)
        {
            nextGenerateTime = Time.time + generateTime;
            generateTime -= 0.005f;
            generateTime = Mathf.Clamp(generateTime, minimumGenerateTime, generateTime);
            GenerateEnemy();
        }
    }

    private void GenerateEnemy()
    {
        EnemyAI generatedEnemy = Instantiate(enemyPrefab, generatePoint.position,
            Quaternion.identity);

        generatedEnemy.SetPatrolPointList(patrolPointList);
    }
}