using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    ZombiSpawner zombiSpawner;
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        FacePlayer();
        Move(deltaTime);
        if (!IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine)); // Cambia al estado de EnemyChasingState
            return;
        }
        else if (IsInSummonRange())
        {
            stateMachine.SwitchState(new EnemySummonState(stateMachine)); // Cambia al estado de EnemyPickupState
            return;
        }
        else if (IsInThrowRange())
        {
            stateMachine.SwitchState(new EnemyThrowingState(stateMachine)); // Cambia al estado de EnemyPickupState
            return;
        }
        stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }
    public override void Exit() {}
}
