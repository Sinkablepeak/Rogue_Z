using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectProjectileState : EnemyBaseState
{ // EnemyDetectProjectileState Class
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    public EnemyDetectProjectileState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("DetectProjectile State");
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {

        if (IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
        else if (IsInThrowRange())
        {
            stateMachine.SwitchState(new EnemyPickUpState(stateMachine)); // Cambia al estado de EnemyChasingState
            return;
        }
        else if (!IsInSummonRange())
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine)); // Cambia al estado de EnemyChasingState
            return;
        }
        else if (IsInVomitRange())
        {
            stateMachine.SwitchState(new EnemyVomitState(stateMachine)); // Cambia al estado de EnemyVomitState
            return;
        }
        //MoveToProjectile(deltaTime);
        //FaceProjectile();
        stateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    //private void MoveToProjectile(float deltaTime)
    //{
    //    if (stateMachine.Agent.isOnNavMesh)
    //    {
    //        stateMachine.Agent.destination = stateMachine.Projectile.transform.position;
    //        Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime *2);
    //    }
    //    stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    //}
} // EnemyDetectProjectileState Class

