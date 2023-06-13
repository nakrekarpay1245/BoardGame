using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateManager))]
public class EnemyAI : MonoBehaviour
{
    [Header("Konum Deðiþkenleri")]
    [HideInInspector]
    public Transform ownTransform;

    [Header("Component Deðiþkenleri")]
    private StateManager stateManager;
    private EnemyMovement enemyMovement;
    private EnemyHealth enemyHealth;

    [Header("State Deðiþkenleri")]
    public EnemyDeadState deadState;
    public EnemyLiveState liveState;

    [Header("State Veri Deðiþkenleri")]
    public DeadStateData deadStateData;
    public LiveStateData liveStateData;

    private void Awake()
    {
        ComponentAttach();
        CreateStates();
    }

    private void Start()
    {
        AddEnemyToList();
        Live();
    }

    #region Awake Functions
    private void ComponentAttach()
    {
        ownTransform = transform;
        stateManager = GetComponent<StateManager>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    #endregion

    #region StartFunctions  
    protected virtual void AddEnemyToList()
    {
    }
    #endregion

    #region Enemy Functions
    public virtual void AttackToBase()
    {
    }

    public virtual void IncreaseManagerCoin()
    {
    }

    protected virtual void RemoveEnemyFromList()
    {
    }

    public void DestroyEnemy()
    {
        RemoveEnemyFromList();
        gameObject.SetActive(false);
    }

    public void SetSpeed(float speed)
    {
        enemyMovement.SetSpeed(speed);
    }

    public void SetStoppingDistance(float stoppingDistance)
    {
        enemyMovement.SetStoppingDistance(stoppingDistance);
    }

    public void SetPatrolPointList(List<Transform> patrolPointList)
    {
        enemyMovement.SetPatrolPointList(patrolPointList);
    }
    #endregion

    #region Create and Change Actions
    public void Live()
    {
        stateManager.ChangeState(liveState);
    }

    public void Dead()
    {
        stateManager.ChangeState(deadState);
    }

    public void CreateStates()
    {
        NewDeadState();
        NewLiveState();
    }

    public void NewDeadState()
    {
        EnemyDeadState newDeadState = new EnemyDeadState(deadStateData, this);
        deadState = newDeadState;
    }

    public void NewLiveState()
    {
        EnemyLiveState newLiveState = new EnemyLiveState(liveStateData, this);
        liveState = newLiveState;
    }
    #endregion

    //#region Editor Functions
    //private void OnDrawGizmos()
    //{
    //}
    //#endregion
}
