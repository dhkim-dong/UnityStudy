using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<EnemyController>
{
    private Animator anim;
    private CharacterController controller;

    protected int hasMove = Animator.StringToHash("Move");

    public override void OnInitailized()
    {
        anim = context.GetComponent<Animator>();
        controller = context.GetComponent<CharacterController>();
    }

    public override void OnEnter()
    {
        anim?.SetBool(hasMove, false);
        controller?.Move(Vector3.zero);
    }

    public override void Update(float deltaTime)
    {
        Transform enemy = context.SearchEnemy();
        if (enemy)
        {
            if (context.IsAvailableAttack)
            {
                stateMachine.ChangeState<AttackState>();
            }
            else
            {
                stateMachine.ChangeState<MoveState>();
            }
        }
    }

    public override void OnExit()
    {
        
    }
}
