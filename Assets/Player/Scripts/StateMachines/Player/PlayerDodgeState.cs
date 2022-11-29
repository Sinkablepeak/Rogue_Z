using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgingState : PlayerBaseState
{
    // Estas variables de solo lectura son para asignar el nombre de la animacion que se utilizo en el Animator
//    private readonly int DodgeBlendTreeHash = Animator.StringToHash("DodgeBlendTree");
    private readonly int DodgeHash = Animator.StringToHash("Dodge");
  //  private readonly int DodgeForwardHash = Animator.StringToHash("DodgeForward");
   // private readonly int DodgeRightHash = Animator.StringToHash("DodgeRight");
    private float remainingDodgeTime;
    private Vector3 dodgingDirectionInput;
    private const float CrossfadeDuration = 0.1f; // Esta variable sirve para especificar cuanto debe tardar al cambiar la animacion en el Estado Enter()
    public PlayerDodgingState(PlayerStateMachine stateMachine, Vector3 dodgingDirectionInput) : base(stateMachine) 
    {
        this.dodgingDirectionInput = dodgingDirectionInput; // Aqui guardamos el valor asignado a la varianle dodgingDirectionInput usando el valor que se pasa en el parametro del constructor, 
    }
    public override void Enter()
    {
        remainingDodgeTime = stateMachine.DodgeDuration;
        //stateMachine.Animator.SetFloat(DodgeForwardHash, dodgingDirectionInput.y); // Aqui se llama a la animacion DiveRoll-Forward del "DodgeBlendTree" pero solo en el eje "y" ya que este es el eje de Forward-Backward, ocea en el "DodgeBlendTree" del Animator, seria lo que este en los campos de PosY de las animaciones 2 y 3 asignadas
        //stateMachine.Animator.SetFloat(DodgeRightHash, dodgingDirectionInput.x); // Aqui se llama a la animacion DiveRoll-Forward del "DodgeBlendTree" pero solo en el eje "x" ya que este es el eje de Left-Right, ocea en el "DodgeBlendTree" del Animator, seria lo que este en los campos de PosX de las animaciones 1 y 4 asignadas
        stateMachine.Animator.CrossFadeInFixedTime(DodgeHash, CrossfadeDuration); // Aqui se llama a las Animaciones Correspondientes para cada direccion.
        stateMachine.Health.SetInvulnerable(true); // Aqui es donde indicamos que es invulnerable mientras esquiva(Dodge)
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement += stateMachine.transform.forward *  stateMachine.DodgeLength ;
        Move(movement,deltaTime);
        //FaceTarget();
        remainingDodgeTime -= deltaTime; // Aqui se reduce el valor de la vairable "remainingDodgeTime"
        if (remainingDodgeTime <= 0f) // Aqui reviso si el tiempo para volver a esquivar ya paso.
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));// Si ya termino el tiempo para volcer a esquivar (Dodge) entonces hacemos el cambio al estado de Targeting o Combate.
        }
    }
    public override void Exit()
    {
        stateMachine.Health.SetInvulnerable(false); // Aqui es donde indicamos que es vulnerable despues de esquivar(Dodge)
    }
}
