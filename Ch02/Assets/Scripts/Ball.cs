using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigid;
    public float speed = 10f;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        startPos = new Vector3(0, 0, 0);

        rigid.AddForce(-speed, 0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 curpos = collision.transform.position;

            Vector3 incomVec = curpos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);

            reflectVec = reflectVec.normalized;

            rigid.AddForce(reflectVec * speed);
            startPos = transform.position;
        }

        if (collision.gameObject.CompareTag("BLOCK"))
        {
            Vector3 curpos = collision.transform.position;

            Vector3 incomVec = curpos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);

            reflectVec = reflectVec.normalized;

            rigid.AddForce(reflectVec * speed);
            startPos = transform.position;
            Destroy(collision.gameObject);
        }
    }
}
