using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(1,50)]
    private float moveSpeed = 10f;
    private float rotateSpeed = 2f;

    Vector3 moveVec;

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float v = Input.GetAxis("Vertical"); 
        float h = Input.GetAxis("Horizontal");

        moveVec = new Vector3(h, 0, v).normalized;

        transform.position += moveVec * moveSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVec), rotateSpeed * Time.deltaTime);

        anim.SetBool("Move", true);
    }


}
