using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hit State Data", menuName = "Finite State Machine / State Data / Hit State Data")]
public class HitStateData : ScriptableObject
{
    [Header("Hareket De�i�kenleri")]
    public float moveSpeed;

    public float rotateSpeed;

    [Header("S�re De�i�kenleri")]
    public float waitTime;

    [Header("Takip/Kovalama De�i�kenleri")]
    public float chaseRadius;
}
