using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleCode : MonoBehaviour
{
    [Range(1,10)]
   public float sightDistance =5f;

    [Range(0,360)]
   public float sightDegree = 90;

    public Vector3[] CalculateSightPoint(float radius, float angle)
    {
        Vector3[] results = new Vector3[2];

        float theta = 90 - angle - transform.eulerAngles.y;
        float posX = Mathf.Cos(theta * Mathf.Deg2Rad) * radius;
        float posY = transform.position.y;
        float posZ = Mathf.Sin(theta * Mathf.Deg2Rad) * radius;
        results[0] = new Vector3(posX, posY, posZ);

        theta = 90 + angle - transform.eulerAngles.y;
        posX = Mathf.Cos(theta * Mathf.Deg2Rad) * radius;
        posY = transform.position.y;
        posZ = Mathf.Sin(theta * Mathf.Deg2Rad) * radius;
        results[1] = new Vector3(posX, posY, posZ);

        return results;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3[] sightPos = CalculateSightPoint(sightDistance, sightDegree);

        for (int i = 0; i < sightPos.Length; i++)
        {
            Gizmos.DrawLine(transform.position, transform.position + sightPos[i]);
        }

        Gizmos.color = Color.green;

        Handles.DrawWireArc(transform.position, Vector3.up, Vector3.forward, 360, sightDistance);
    }
}
