using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase no hereda del MonoBehaviour ya que es usada para crear los estados o States -
//que seran utilizados en el script de StateMachine, al quitar el MonoBehaviour significa que -
//no podremos adjuntar este script en algun gameObject.
public abstract class State
{
    public abstract void Enter(); // Entre a un nuevo estado.
    public abstract void Tick(float deltaTime); // Se mantiene en el estado que llamamos usando Enter().
    public abstract void Exit(); // Sale del estado en el que se encuentre.
    protected float GetNormalizaTime(Animator animator)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfo.IsTag("Attack"))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}