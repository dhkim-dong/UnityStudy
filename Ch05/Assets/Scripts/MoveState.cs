using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State<EnemyController>
{
    private Animator anim;
    private CharacterController controller;
    private NavMeshAgent agent;

    private int hashMove = Animator.StringToHash("Move");

    public override void OnInitailized()
    {
        anim = context.GetComponent<Animator>();
        controller = context.GetComponent<CharacterController>();
        agent = context.GetComponent<NavMeshAgent>();
    }

    public override void OnEnter()
    {
        agent?.SetDestination(context.target.position);
        anim?.SetBool(hashMove, true);
    }

    public override void Update(float deltaTime)
    {
        Transform enemy = context.SearchEnemy();

        if (enemy)
        {
            agent.SetDestination(context.target.position);
            if(agent.remainingDistance > agent.stoppingDistance)
            {
                controller.Move(agent.velocity * deltaTime);
            }
        }

        if(!enemy || agent.remainingDistance <= agent.stoppingDistance)
        {
            stateMachine.ChangeState<IdleState>();
        }
    }

    public override void OnExit()
    {
        anim?.SetBool(hashMove, false);
        agent.ResetPath();
    }
}
