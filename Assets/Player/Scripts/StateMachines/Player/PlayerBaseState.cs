using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected void Move(float deltaTime)
    {
        Move(Vector3.zero,deltaTime);
    }
    protected void Move(Vector3 motion, float deltaTime) // Este Metodo es el encargado de mover al jugador llamando al metodo Move del character Controller
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);  //El metodo Move() de esta linea es el que se crear en el Character Controller
    }
}
