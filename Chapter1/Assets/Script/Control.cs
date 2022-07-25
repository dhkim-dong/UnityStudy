using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    Vector3 moveVec;

    Rigidbody rigid;

    [SerializeField] float jump;
    [SerializeField] float speed;
    [SerializeField] GameObject target;

    public bool isJump = false;

    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Debug.Log("Start");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            isJump = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            rigid.AddForce(-speed, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            rigid.AddForce(speed, 0, 0, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W) == true)
        {
            rigid.AddForce(0, 0, speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            rigid.AddForce(0, 0, -speed, ForceMode.Impulse);
        }



        //Debug.Log("Update");
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
