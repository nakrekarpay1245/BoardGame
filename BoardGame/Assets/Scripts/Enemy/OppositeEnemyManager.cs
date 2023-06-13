using System.Collections.Generic;
using UnityEngine;

public class OppositeEnemyManager : MonoSingleton<OppositeEnemyManager>
{
    [Header("All Enemies")]
    [SerializeField]
    private List<EnemyAI> enemyList;

    private EnemyAI closedEnemy;

    public void AddEnemyToList(EnemyAI enemy)
    {
        if (!enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);
        }
    }

    public EnemyAI GetClosedEnemy(Vector3 detectPosition)
    {
        if (enemyList.Count > 0)
        {
            closedEnemy = enemyList[0];

            for (int i = 0; i < enemyList.Count; i++)
            {
                float distanceFromCurrentCarEnemy =
                    Vector3.Distance(closedEnemy.transform.position, detectPosition);

                float distanceFromNextCarEnemy =
                    Vector3.Distance(enemyList[i].transform.position, detectPosition);

                if (distanceFromNextCarEnemy < distanceFromCurrentCarEnemy)
                {
                    closedEnemy = enemyList[i];
                }
            }
            return closedEnemy;
        }
        return null;
    }

    public EnemyAI GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.Count);
        EnemyAI randomEnemy = enemyList[randomIndex];
        return randomEnemy;
    }

    public void RemoveEnemyFromList(EnemyAI enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }
}
