using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRange = 5.0f;
    [Range(0, 360)]   // 변수 슬라이더 적용가능
    public float viewAngle = 90f;

    public LayerMask targetmask;
    public LayerMask obstacleMask;

    public List<Transform> visibleList = new List<Transform>();

    private Transform nearestTarget;
    private float distanceToTarget = 0f;

    private void Update()
    {
        FindVisibleTarget();
    }


    #region Methods

    public void FindVisibleTarget()
    {
        // physics. raycasthit 사용하여 거리각 내의 적을 탐색한다
        distanceToTarget = 0f;
        nearestTarget = null;
        visibleList.Clear();

        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRange,targetmask);
        for (int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;

            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward,dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleList.Add(target);
                    if(nearestTarget == null || (distanceToTarget > dstToTarget))
                    {
                        nearestTarget = target;
                        distanceToTarget = dstToTarget;
                    }
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) 
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    #endregion Methods
}
