 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;
    
    // Este metodo cambia de estado (State)
    public void SwitchState(State newState)
    {
        currentState?.Exit(); // El ? es para no escribir un if en este caso significa que si el currentState es = null entonces llama al estado o State Exit()
        currentState = newState; // Cambia el estado (State) la cual sera llamado en la siguiente linea
        currentState?.Enter(); // Llama al estado Enter()
    }
    private void Update()
    {
        currentState?.Tick(Time.deltaTime);
    }
}
