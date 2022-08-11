using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    public float walkSpeed = 10.0f;
    public float jumpSpeed =10.0f;

    SpriteRenderer render;
    Animator anim;
    Rigidbody2D rigid;
    public bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FreezeRotation();
        SetPlayerPos();
        if (Input.GetKey(KeyCode.Space) && !isJump)
        {
            isJump = true;
            anim.SetBool("Run", false);
            rigid.AddForce(Vector2.up * jumpSpeed ,ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
        }   

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(!isJump)
            anim.SetBool("Run", true);
            render.flipX = true;
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(!isJump)
            anim.SetBool("Run", true);
            render.flipX = false;
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Run", false);
        }     
    }

    void SetPlayerPos()
    {
        if (transform.position.x < -10)
            transform.position = new Vector2(-10, transform.position.y);

        if (transform.position.x > 10)
            transform.position = new Vector2(10, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("GROUND"))
        {
            isJump = false;
        }
    }

    void FreezeRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
