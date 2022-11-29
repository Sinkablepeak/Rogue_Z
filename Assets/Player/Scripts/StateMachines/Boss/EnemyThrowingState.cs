using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowingState : EnemyBaseState
{
    private readonly int ThrowHash = Animator.StringToHash("Throw");
    private const float CrossFadeDuration = 0.1f;
    public Rigidbody projectileRB;
    public EnemyThrowingState(EnemyStateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
        //Debug.Log("Throwing State");
        stateMachine.Animator.CrossFadeInFixedTime(ThrowHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        if (GetNormalizaTime(stateMachine.Animator) > 1 )
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
        }
        FacePlayer();
    }
    public override void Exit() { }
}