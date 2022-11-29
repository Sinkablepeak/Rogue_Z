using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummonState : EnemyBaseState
{
    private readonly int SummonHash = Animator.StringToHash("Summon");
    private const float CrossFadeDuration = 0.1f;
    public EnemySummonState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        //Debug.Log("Summon State");
        stateMachine.Animator.CrossFadeInFixedTime(SummonHash, CrossFadeDuration);
        stateMachine.ZombiesSpawner.SetActive(true);
    }
    public override void Tick(float deltaTime)
    {
        if (GetNormalizaTime(stateMachine.Animator) >= 1)
        {
            if (IsInSummonRange())
            {
                stateMachine.SwitchState(new EnemyThrowingState(stateMachine)); // Cambia al estado de EnemyVomitState
                return;
            }
            else if (!IsInSummonRange())
            {
                stateMachine.SwitchState(new EnemyIdleState(stateMachine)); // Cambia al estado de EnemyVomitState
                return;
            }
        }
        else if (IsInVomitRange())
        {
            stateMachine.SwitchState(new EnemyVomitState(stateMachine)); // Cambia al estado de EnemyVomitState
            return;
        }
        FacePlayer();
    }
    public override void Exit()
    {
        stateMachine.ZombiesSpawner.SetActive(false);
    }
}