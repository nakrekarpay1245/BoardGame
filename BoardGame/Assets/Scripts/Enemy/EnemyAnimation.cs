using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAnimation : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AnimationRoutine());
    }

    private IEnumerator AnimationRoutine()
    {
        while (true)
        {
            transform.DOScaleY(1f, TimeManager.GetUIDelay4());
            yield return new WaitForSeconds(TimeManager.GetUIDelay4());

            transform.DOScaleY(0.9f, TimeManager.GetUIDelay4());
            yield return new WaitForSeconds(TimeManager.GetUIDelay4());
        }
    }
}
