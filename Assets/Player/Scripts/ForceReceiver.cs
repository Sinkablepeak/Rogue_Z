using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float drag = 0.3f;
    private Vector3 dampingVelocity;
    private Vector3 impact;
    private float verticalVelocity;
    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    private void Update()
    {
        if (verticalVelocity < 0f && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime; // Aqui se agrega fuerza en el eje Y para simular que hay gravedad, de esta manera jala al player siempre hacia abajo
        }

        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);
        if (agent != null)
        {
            if (impact.sqrMagnitude < 0.2f * 0.2f)
            {
                impact = Vector3.zero;
                agent.enabled = true;
            }
        }
    }
    public void AddForce(Vector3 force)
    {
        impact += force;
        if(agent != null)
        {
            agent.enabled = false;
        }
    }
    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;
    }
    public void Reset() // Este Metodo se usa en el Script (State Machine o Estado) PlayerHangingState para evitar que caiga de putazo al soltarse del Ledge o Borde al presionar el boton "B" o la tecla "s" 
    {
        impact = Vector3.zero;
        verticalVelocity = 0f;
    }
}