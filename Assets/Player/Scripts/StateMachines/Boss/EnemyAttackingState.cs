using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("Attack");
    private const float TransitionDuration = 0.1f;
    private Attack attack;
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        //Debug.Log("Attacking State");
        stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockBack);
        stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
        FacePlayer();
    }
    public override void Tick(float deltaTime)
    {
        if(GetNormalizaTime(stateMachine.Animator) >= 1)
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
        }
    }
    public override void Exit() { }
}
