using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVomitState : EnemyBaseState
{
    private readonly int VomitHash = Animator.StringToHash("Vomit");
    private const float CrossFadeDuration = 0.1f;
    public GameObject Player;
    public Transform zombiHead;
    public EnemyVomitState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(VomitHash, CrossFadeDuration);
        FacePlayer();
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.InstantiateVomit();
        if (GetNormalizaTime(stateMachine.Animator) >= 1)
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine)); // Cambia al estado de EnemyChasingState
        }
            else if(IsInAttackRange())
            {
                stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
                return;
            }
    }

    //private void GetAngle()
    //{
    //    Vector3 direction = (Player.transform.position - this.stateMachine.transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    this.stateMachine.transform.rotation = Quaternion.Slerp(this.stateMachine.transform.rotation, lookRotation, Time.deltaTime * rotSpeed);
    //    float? angle = RotateHead();
    //    if (angle != null)
    //    {
    //        CreateThrowObject();
    //    }
    //    else
    //    {
    //        this.stateMachine.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    //    }
    //}

    public override void Exit() { }
    //void CreateThrowObject()
    //{
    //    GameObject vomit = stateMachine.InstantiateVomit();
    //    vomit.GetComponent<Rigidbody>().velocity = stateMachine.throwObjectSpeed * zombiHead.forward;  
    //}
    //float? RotateHead()
    //{
    //    float? angle = CalculateAngle(false);
    //    if (angle != null)
    //    {
    //        zombiHead.localEulerAngles = new Vector3(0f, 360f - (float)angle, 0f);
    //    }
    //    return angle;
    //}
    //float? CalculateAngle(bool low)
    //{
    //    Vector3 targetDir = Player.transform.position - this.stateMachine.transform.position;
    //    float y = targetDir.y;
    //    targetDir.y = 0f;
    //    float x = targetDir.magnitude - 2;
    //    float gravity = 9.8f;
    //    float sSqr = stateMachine.throwObjectSpeed * stateMachine.throwObjectSpeed;
    //    float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);
    //    if (underTheSqrRoot >= 0)
    //    {
    //        float root = Mathf.Sqrt(underTheSqrRoot);
    //        float highAngle = sSqr + root;
    //        float lowAngle = sSqr - root;

    //        if (low)
    //            return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
    //        else
    //            return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
    //    }
    //    else 
    //        return null;
    //}
}
