using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private readonly int PatrolHash = Animator.StringToHash("Patrol");
    private const float CrossFadeDuration = 0.1f;
    public EnemyPatrolState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Patrol State");
        stateMachine.Animator.CrossFadeInFixedTime(PatrolHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if (GetNormalizaTime(stateMachine.Animator) >= 1)
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine)); // Cambia al estado de EnemyVomitState
        }
    }
    public override void Exit() { }
}