using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌 Enter : " + collision.gameObject.name);
    }


    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 Exit : " + collision.gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
