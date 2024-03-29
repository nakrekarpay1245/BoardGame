using UnityEngine;

[CreateAssetMenu(fileName = "Attack State Data", menuName = "Finite State Machine / State Data / Attack State Data")]

public class AttackStateData : ScriptableObject
{
    [Header("Hareket Değişkenleri")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Algılama Değişkenleri")]
    public float attackRadius;
    public float chaseRadius;

    [Header("Saldırı Değişkenleri")]
    public float attackTime = 3;

    [Header("Bekleme Değişkenleri")]
    public float attackWaitTime = 1;
}
