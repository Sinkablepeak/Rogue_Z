using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }
    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }
    protected bool IsInChaseRange() 
    {
        if (stateMachine.Player.isDead) { return false; }
        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;
    }
    protected bool IsInSummonRange()
    {
        if (stateMachine.Player.isDead) { return false; }
        float SummonDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return SummonDistanceSqr <= stateMachine.SummonRange * stateMachine.SummonRange;
    }
    protected bool IsInVomitRange()
    {
        if (stateMachine.Player.isDead) { return false; }
        float vomiteDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return vomiteDistanceSqr <= stateMachine.PlayerVomitRange * stateMachine.PlayerVomitRange;
    }
    protected bool IsInThrowRange()
    {
        if (stateMachine.Player.isDead) { return false; }
        float vomiteDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return vomiteDistanceSqr <= stateMachine.ThrowingRange * stateMachine.ThrowingRange;
    }
    protected bool IsInAttackRange()
    {
        if (stateMachine.Player.isDead) { return false; }

        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }
    protected void FacePlayer()
    {
        if (stateMachine.Player == null) { return; }
        // Forma 1 medir la distancia entre el boss y el Player usando el Teorema de Pitagoras | Raiz(x1-x2)^2 + (y1-y2)^2 | Raiz| (x^2 +y^2))
        float distance = Mathf.Sqrt(Mathf.Pow(stateMachine.Player.transform.position.x - this.stateMachine.transform.position.x, 2)
                       + Mathf.Pow(stateMachine.Player.transform.position.y - this.stateMachine.transform.position.y, 2));
        //Debug.Log("Distancia: " + distance);
        
        // Forma 2 de usando el metodo que contiene Unity la cual usa el teorema de Pitagoras como se hizo en la forma 1, en este caso el metodo emebido de unity se llama Vector3.Distance
        Vector3 PlayerPos = new Vector3(stateMachine.Player.transform.position.x, stateMachine.Player.transform.position.y, 0);
        Vector3 BossPos = new Vector3(stateMachine.transform.position.x, stateMachine.transform.position.y, 0);
        float uDistance = Vector3.Distance(PlayerPos, BossPos);
        //Debug.Log("uDistancia: " + uDistance);

        // Sacando la Magnitud o el largo de un Vector se puede medir la distancia entre 2 objetos.
        Vector3 bossTopPlayer = PlayerPos - BossPos;
        //Debug.Log("V Magnitude: " + bossTopPlayer.magnitude);
        //Debug.Log("V SqrMagnitude: " + bossTopPlayer.sqrMagnitude); // usando SqrMagnitude se ahorran recursos ya que es mas pesado sacar la Raiz cuadrada usada en Vector3.magnitude, ocea que Vector3.sqrMagnitude es mas rapido.

        // Calcular Angulo entre el bos y el Player usando el producto punto visto con el profe Cesar
        Vector3 bossForward = stateMachine.transform.forward;
        Vector3 playerDirecction = stateMachine.Player.transform.position;
        //Debug.DrawRay(stateMachine.transform.position, bossForward * 20, Color.red, 15);
        //Debug.DrawRay(stateMachine.transform.position, playerDirecction, Color.green, 15);

        float dot = bossForward.x * playerDirecction.x + bossForward.z * playerDirecction.z;
        float angle = Mathf.Acos(dot / (bossForward.magnitude * playerDirecction.magnitude));
        //Debug.Log("Angulo: " +  angle * Mathf.Rad2Deg);
        //Debug.Log("Unity Angulo: " + Vector3.Angle(bossForward , playerDirecction));

        
        int clockWise = 1;
        if (Cross(bossForward, playerDirecction).z <= 0)
            clockWise = -1;
        stateMachine.transform.Rotate(0,0, angle * Mathf.Rad2Deg *  clockWise);

        // Rotar al bos hacia el player
        Vector3 lookPos = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookPos.y = 0f;
        stateMachine.transform.rotation = Quaternion.LookRotation(lookPos);
    }
    Vector3 Cross(Vector3 v,  Vector3 w)
    {
        // Calcular el producto Cruz  para saber si debe girar en contra o no a las manecillas del reloj 
        float xMult = v.y * w.z - v.z * w.y;
        float yMult = v.x * w.z - v.z * w.x;
        float zMult = v.x * w.y - v.y * w.x;

        return (new Vector3(xMult, yMult, zMult));
    }
}
