using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid;
    public float speed = 10.0f;
    [SerializeField] Vector3 startPos;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0, 0, 0);
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
        }
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(-speed,0,0);
            //transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(speed,0,0);
            //transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigid.AddForce(0,0,speed);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigid.AddForce(0,0,-speed);
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rigid.AddForce(0, speed, 0);
        }
    }
}
