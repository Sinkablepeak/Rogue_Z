using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private bool shouldFade;
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash( "FreeLookBlendTree");
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    private Vector3 movement;
    public PlayerFreeLookState(PlayerStateMachine _stateMachine, bool shouldFade = true) : base(_stateMachine) 
    {
        this.shouldFade = shouldFade;
    }
    public override void Enter()
    {
        stateMachine.InputReader.DodgeEvent += OnDodge;
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0f);
        if (shouldFade)
        {
            stateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTreeHash, CrossFadeDuration);
        }
        else
        {
            stateMachine.Animator.Play(FreeLookBlendTreeHash);
        }
    }
    public override void Tick(float deltaTime)
    {
        if (stateMachine.InputReader.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }

        movement = CalculateMovement();
        Move(movement * stateMachine.FreeLookMovementSpeed, deltaTime);
        
        if (stateMachine.InputReader.MovementValue == Vector2.zero) // Aqui se especifica si no se recibe ningun Input entonces dejar de mover o Rotar al Player y llamar la animacion de idle 
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movement, deltaTime);
    }
    public override void Exit()
    {
        stateMachine.InputReader.DodgeEvent -= OnDodge;
    }
    private void OnDodge()
    {
        Vector3 movement = CalculateMovement();
        //if (stateMachine.InputReader.MovementValue == Vector2.zero) { return; } // Aqui se revisa si no hay movimiento(si no se movio el Stick Isquiero o WASD), entonces no ejecutar la animacion de Dodge, esto para evitar ejecutar la animacion de dodge si no se esta moviendo el personaje.
        stateMachine.SwitchState(new PlayerDodgingState(stateMachine, stateMachine.InputReader.MovementValue)); // Aqui se llama el StateMachine PlayerDodgingState
        FaceMovementDirection(movement, 1);
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
