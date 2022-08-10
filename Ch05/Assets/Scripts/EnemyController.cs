using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public LayerMask targetMask;
    public float viewRadius;
    public Transform target;
    public float attackRange;

    protected StateMachine<EnemyController> statemachine;

    private void Start()
    {
        statemachine = new StateMachine<EnemyController>(this, new IdleState());
        statemachine.AddState(new MoveState());
        statemachine.AddState(new AttackState());
    }

    private void Update()
    {
        statemachine.Update(Time.deltaTime);
    }


    public bool IsAvailableAttack
    {
        get
        {
            if (!target)
                return false;

            float distance = Vector3.Distance(transform.position, target.position);
            return (distance <= attackRange);
        }
    }

    public Transform SearchEnemy()
    {
        target = null;
        Collider[] targetinViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (targetinViewRadius.Length > 0)
        {
            target = targetinViewRadius[0].transform;
        }
        return target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
    
