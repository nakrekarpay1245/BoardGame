using UnityEngine;

[CreateAssetMenu(fileName = "Live State Data", menuName = "Finite State Machine / State Data / Live State Data")]
public class LiveStateData : ScriptableObject
{
    [Header("Hareket Deðiþkenleri")]
    public float moveSpeed;
    [Header("Hareket Deðiþkenleri")]
    public float stoppingDistance = 0.005f;
}
