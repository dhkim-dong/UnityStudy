using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<EnemyController>
{
    private Animator anim;
    private int hashAttack = Animator.StringToHash("Attack");

    public override void OnInitailized()
    {
        anim = context.GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        if (context.IsAvailableAttack)
        {
            Debug.Log("OnAttackEnter");
            anim?.SetTrigger(hashAttack); // ?문법 C# ?문법
            stateMachine.ChangeState<IdleState>();
        }
        else
        {
            stateMachine.ChangeState<IdleState>();
        }
    }

    public override void Update(float deltaTime)
    {
        
    }
}
