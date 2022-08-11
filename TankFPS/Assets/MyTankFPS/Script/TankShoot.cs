using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody shellPrefab;
    public Transform shellPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetShellShoot();
    }

    public void SetShellShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody fire = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
            fire.velocity = transform.forward * 20f;
        }
    }
}
