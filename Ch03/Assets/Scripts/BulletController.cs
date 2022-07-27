using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody rigid;

    float bulletSpeed = 1000f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    rigid.AddForce(0, 0, bulletSpeed);
        //}       
    }

    public void BulletFire()
    {
        rigid.AddForce(0, 0, bulletSpeed);
    }

    public void BulletEnemyFire()
    {
        rigid.AddForce(0, 0, -bulletSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ENEMY"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
