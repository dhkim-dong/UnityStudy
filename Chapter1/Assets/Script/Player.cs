using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 moveVec;

    [SerializeField] float jump;
    [SerializeField] float speed;
    [SerializeField] GameObject target;

    public bool isJump = false;

    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log("Awake");
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
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.UpArrow) == true)
        //{
        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    transform.Translate(Vector3.back * speed * Time.deltaTime);
        //}

        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            isJump = true;
            transform.position += new Vector3(0, jump, 0) * Time.deltaTime;
        }


        float ver = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        moveVec = new Vector3(hori, 0, ver).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        //Debug.Log("Update");
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
