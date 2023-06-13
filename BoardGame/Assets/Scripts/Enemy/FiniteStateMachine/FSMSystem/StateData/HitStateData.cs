using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hit State Data", menuName = "Finite State Machine / State Data / Hit State Data")]
public class HitStateData : ScriptableObject
{
    [Header("Hareket Deðiþkenleri")]
    public float moveSpeed;

    public float rotateSpeed;

    [Header("Süre Deðiþkenleri")]
    public float waitTime;

    [Header("Takip/Kovalama Deðiþkenleri")]
    public float chaseRadius;
}
