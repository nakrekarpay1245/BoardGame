using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [Header("All Enemies")]
    [SerializeField]
    private List<EnemyMovement> enemyList;

    private EnemyMovement closedEnemy;
    public void AddEnemyToList(EnemyMovement enemy)
    {
        if (!enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);
        }
    }

    public void RemoveEnemyFromList(EnemyMovement enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
        }
    }

    public EnemyMovement GetClosedEnemy(Vector3 detectPosition)
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
}
