using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private float previousFrameTime;
    private bool alreadyAppliedForce;
    private Attack attack;
    private Vector3 movement;
    public PlayerAttackingState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine) 
    {
        attack = stateMachine.Attacks[attackIndex];
    }
    public override void Enter()
    {
        movement = CalculateMovement();
        stateMachine.Weapon.SetAttack(attack.Damage, attack.KnockBack);
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
        FaceMovementDirection(movement, 1);
    }
    public override void Tick(float deltaTime)
    {
        Move(deltaTime);
        //FaceTarget();
        float normalizedTime = GetNormalizaTime(stateMachine.Animator);
        if (normalizedTime >= previousFrameTime && normalizedTime < 1f)
        {
            if (normalizedTime >= attack.ForceTime)
                TryApplyForce();
            if (stateMachine.InputReader.IsAttacking)
                TryComboAttack(normalizedTime);
        }
        else
                stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        previousFrameTime = normalizedTime;
    }
    public override void Exit() { }
    private void TryComboAttack(float normalizedTime)
    {
        if(attack.ComboStateIndex == -1) { return; }
       
        if (normalizedTime < attack.ComboAttackTime) { return; }
        stateMachine.SwitchState
        (
            new PlayerAttackingState
            (
                stateMachine,
                attack.ComboStateIndex
            )
        );
    }
    private void TryApplyForce()
    {
        if (alreadyAppliedForce) { return; }
        stateMachine.ForceReceiver.AddForce(stateMachine.transform.forward * attack.Force);
        alreadyAppliedForce = true;
    }
    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y
               + right * stateMachine.InputReader.MovementValue.x;
    }
    private void FaceMovementDirection(Vector3 movement, float deltaTime) // Rotar al Player hacia la direccion que mira 
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
                    stateMachine.transform.rotation,
                    Quaternion.LookRotation(movement),
                    deltaTime * stateMachine.RotationDamping);
    }
}