using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPickUpState : EnemyBaseState
{
    private readonly int PickUpHash = Animator.StringToHash("PickUp");
    private const float CrossFadeDuration = 0.1f;
    public EnemyPickUpState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("PickUp State");
        stateMachine.Animator.CrossFadeInFixedTime(PickUpHash, CrossFadeDuration);
        stateMachine.InstantiateProjectile();
    }
    public override void Tick(float deltaTime)
    {
        if (GetNormalizaTime(stateMachine.Animator) >= 1)
        {
            stateMachine.SwitchState(new EnemyThrowingState(stateMachine)); // Cambia al estado de EnemyChasingState
            return;
        }

        FacePlayer();
    }
    public override void Exit() 
    {

    }
}